using System.Reflection;

namespace CompanyServer.Core.Domain.SeedWork;

/// <summary>
/// 值对象的基类
/// 值对象是领域驱动设计 (Domain-Driven Design, DDD) 中的概念，用于表示没有唯一标识符的、不可变的、完全由其属性确定的对象。
/// </summary>
public class ValueObject : IEquatable<ValueObject>
{
    private List<PropertyInfo> _propertyInfos;
    private List<FieldInfo> _fields;

    public static bool operator ==(ValueObject object1, ValueObject object2)
    {
        if (Equals(object1, null))
        {
            if (Equals(object2, null))
            {
                return true;
            }

            return false;
        }

        return object1.Equals(object2);
    }

    public static bool operator !=(ValueObject object1, ValueObject object2)
    {
        return !(object1 == object2);
    }

    public bool Equals(ValueObject obj)
    {
        return Equals(obj as object);
    }

    /// <summary>
    /// 重写了 Equals 方法：根据类型和属性逐一比较两个对象是否相等。
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return GetProperties().All(x => PropertiesAreEqual(obj, x)) && GetFields().All(x => FieldsAreEqual(obj, x));
    }

    /// <summary>
    /// 用于比较对象的属性值和字段值是否相等。
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    private bool PropertiesAreEqual(object obj, PropertyInfo p)
    {
        return Equals(p.GetValue(this, null), p.GetValue(obj, null));
    }

    private bool FieldsAreEqual(object obj, FieldInfo f)
    {
        return Equals(f.GetValue(this), f.GetValue(obj));
    }

    /// <summary>
    /// 获取对象的属性和字段列表，排除带有 IgnoreMemberAttribute 特性的成员。
    /// </summary>
    /// <returns></returns>
    private IEnumerable<PropertyInfo> GetProperties()
    {
        return _propertyInfos ??= GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
            .ToList();
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        return _fields ??= GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null).ToList();
    }


    /// <summary>
    /// 据对象的类型和属性生成哈希码，用于在集合中查找和比较值对象。
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hash = GetProperties().Select(prop => prop.GetValue(this, null))
            .Aggregate(17, HashValue);

        return GetFields().Select(field => field.GetValue(this)).Aggregate(hash, HashValue);
    }

    /// <summary>
    /// 根据当前哈希码和属性值计算新的哈希码。
    /// </summary>
    /// <param name="seed"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private static int HashValue(int seed, object value)
    {
        var currentHash = value?.GetHashCode() ?? 0;
        return seed * 23 + currentHash;
    }
}

/// <summary>
/// 定义值对象基类 
/// 注意没有唯一标识了
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// 重写方法 相等运算
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        var valueObject = obj as T;
        return !ReferenceEquals(valueObject, null) && EqualsCore(valueObject);
    }

    protected abstract bool EqualsCore(T other);

    /// <summary>
    /// 获取哈希
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }

    protected abstract int GetHashCodeCore();

    /// <summary>
    /// 重写方法 实体比较 ==
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    /// <summary>
    /// 重写方法 实体比较 !=
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }

    /// <summary>
    /// 克隆副本
    /// </summary>
    public virtual T Clone()
    {
        return (T)MemberwiseClone();
    }
}