# DDD 学习 Demo  还在完善中....

这是一个用于学习领域驱动设计（DDD）的简单演示项目。该项目旨在展示如何实现 DDD 中的核心概念和模式，以及如何应用它们来构建具有良好架构的软件系统。

## 功能特性

- **聚合根 (Aggregate Root)**: 展示如何定义和管理聚合根，以及聚合根之间的关系。
- **实体 (Entity)**: 展示如何定义实体、标识和实体之间的业务逻辑。
- **值对象 (Value Object)**: 展示如何定义值对象，以及如何处理值对象的不可变性。
- **领域事件 (Domain Events)**: 展示如何创建和使用领域事件，以及如何组织事件的发布和处理。
- **领域服务 (Domain Services)**: 展示如何实现领域服务，以及如何在领域层中进行业务操作。

## 项目架构
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/e4143da1-b35c-4254-999c-52c4a971ec52)
### Api 层
- 这是项目的外部接口层，用于处理 HTTP 请求并向客户端提供服务。
- 它包含控制器（Controllers），用于定义不同的路由和处理请求。这些控制器将请求传递给 Core 层进行处理，并返回响应给客户端。
  
### Core 层

![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/09a9005e-cf59-4479-a83d-834fff31dd1f)

#### Application（应用）: 层协调领域对象之间的交互，处理用户的请求，并调用适当的领域服务来执行业务逻辑。

![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/8d3a306d-f7ae-494c-9cb1-10186d852dda)

CompanyHandler ：文件主要实现: 接收从MediatR 传过来的Command 的处理机制。

Configuration ：

  Behaviours ：
  
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/d9bc5175-8d86-4fd6-b0a3-bdc75646a4e1)

  Commands ：
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/4a048263-7cc3-459f-9ad9-0e43280c3a87)
  
  Data ：
  
  ISqlConnectionFactory:
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/6c3c920e-7ead-48ab-935e-7938eac47a9e)
  
  ITransactionContext:
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/14ae83fe-d644-40a4-86e6-d3fbf54fe195)

    
  



#### Data(数据):Data 模块用于处理数据访问和持久化的相关逻辑
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/ef3d1943-3c01-4b57-976d-e5819c9e2a4e)

#### Domain(领域): 是整个核心层的核心，它包含了应用程序的核心业务逻辑和领域模型。模块定义了领域的概念、实体、值对象、聚合根以及领域服务等.
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/047ef80a-0c25-4bdd-873a-79c5b9caa290)

- Companys ：表示业务领域中的不同公司实体。
  
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/560bf3fb-6bf2-4840-ae5b-9b0e39845048)
  
  Company类：Company 可能是表示公司实体。在DDD中，公司被视为领域模型中的核心概念之一，具有自己的属性、行为和业务规则。
  
  CompanyEntityTypeConfiguration类：将 Company 实体映射到数据存储中的关系数据库。在DDD中，这种配置类常用于ORM（对象关系映射）框架，以便将领域实体与数据库表进行映射。
  
  ICompanyRepository：定义了对于 Company 实体的持久化与查询操作。在DDD中，仓储（Repository）模式通常用于管理领域实体的持久化，该接口定义了对于 Company 实体的增删改查等方法。
  
  Warehouse：在DDD中，Warehouse 可能被视为领域模型中的另一个核心概念，具有自己的属性、行为和业务规则。
  
  WarehouseEntityTypeConfiguration：用于定义如何将 Warehouse 实体映射到数据存储中的关系数据库。
  
  
- SeedWrok ：Seed Work（种子工作）是一种软件开发模式，旨在通过创建和验证基础架构代码来帮助项目启动。在领域层中，Seed Work 可能指的是一些用于快速原型开发和迭代的基础设施代码或类。
  
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/49839694-def8-4931-be0b-25178ebcab88)
  
  DomainEventBase（领域事件基类）: DomainEventBase 可能是一个基类，用于实现领域事件的通用行为和属性。在DDD中，领域事件用于记录领域模型中发生的重要事实或状态变化，以便在系统中进行响应和处理。
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/714531c7-9122-4572-8a1d-40dfcb22c9b0)

  Entity（实体）:
  
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/d09eb187-0c35-491d-b46f-5ae516f8b262)

  IAggregateRoot（聚合根接口）:
  
  IDomainEvent（领域事件接口）:
  
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/60ccea28-6e58-4883-8815-fcb61f9bfc1a)
  
  IDomainEventsDispatcher（领域事件分发器接口）:

  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/da56b404-c916-41ab-8ecf-e36265574b7d)

  IgnoreMemberAttribute（成员忽略属性）:

  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/93f50133-0bf6-41bc-bff5-a84c766938dd)


  IRepository（仓储接口）:

  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/ff2ef923-1bc2-4c78-9d83-ed8c1bafd336)

  IUnitOfWork（工作单元接口）:

  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/389058ce-a782-43d6-a5a8-b90037ce122b)


  ValueObject（值对象）: 具体作用在下方有描述

- ShareKernel ：Share Kernel（共享内核）是指操作系统中多个进程共享的核心部分，以提供资源共享和进程间通信。在领域层中，ShareKernel 可能指的是领域模型中被多个领域实体共享的核心概念或逻辑。
 
  这里目前只有一个Address:
  
- Warehouses ：

  IWarehouseChecker ：该接口可能用于仓库（Warehouse）的验证操作。
  IWarehouseRepository ：仓库（Warehouse）的数据访问层接口,仓库领域模型的数据访问操作抽象出来
  WarehouseBusinessValidateException ：自定义异常类，用于表示仓库业务验证异常

  
- IEntity ：用于表示领域模型中的实体对象，其他实体类可以实现该接口以符合一致的规范。


#### Extensions(扩展): 模块用于扩展其他模块或框架的功能，为领域对象提供一些通用的扩展方法或工具类。
#### Infrastructure(基础设施):负责处理与基础设施相关的实现，例如数据库连接、文件系统、网络通信等。
- **Infrastructure

    1.1 DataAccessModule：这个模块负责配置和管理数据访问相关的组件，例如仓储实现、数据库连接工厂等 
   
    1.2 MySqlConnectionFactory：这是一个数据库连接工厂，用于创建和管理与 MySQL 数据库的连接。
- 2.**Domain
 
  2.1 CompanyRepository：这是一个仓储接口，定义了对公司领域实体的持久化和检索操作。
  
  2.2 DomainEventsDispatcher：领域事件派发器负责将领域内发生的事件分发给对应的事件处理器。
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/73b43591-cb26-4689-a488-22c3b0bf53c7)

  
  2.3 DomainModule：这个模块负责配置和管理领域层相关的组件，例如领域服务、聚合根等。
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/44b68f75-f194-415d-b653-5ce292eed5a2)

  
  2.4 SpecificationExtensions：这个扩展类提供了一些用于在领域中编写规约（Specification）的辅助方法。
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/ebd9e117-3355-4d53-a8ab-8e795d1bd2c9)

  
    
- 3.**Mediator  是一种模式，它用于解耦领域对象之间的直接交互
  
   3.1 MediatorExtensions：这个扩展类提供了一些用于简化在领域中使用 Mediator 模式的辅助方法。
    ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/9e074274-c95d-4ecd-b500-505649366e8f)
   3.2 MediatorModule：这个模块负责配置和管理中介者相关的组件，例如处理器注册、管道配置等。
  ![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/bffa4a75-4b87-4fd0-afef-ed9f9decd74b)

  
#### 通过将不同的组件划分到不同的模块中，Infrastructure 层实现了对不同领域概念和技术实现的组织和管理。DataAccessModule 和 MySqlConnectionFactory 提供了与数据访问相关的功能，CompanyRepository 和 DomainEventsDispatcher 则涉及到与领域对象的交互.DomainModule 配置领域层组件，SpecificationExtensions 提供了领域规约的支持。 Mediator 和 MediatorExtensions 是为了解耦领域对象之间的交互而引入的。这种分层和组织的方式有助于保持代码的可维护性和可测试性，同时也便于团队成员理解和修改代码。

  

- Services(服务)：Services 模块用于实现一些可重用的服务或业务逻辑，供其他模块调用。
- Settings(配置):Settings 模块用于存储应用程序的配置信息，例如数据库连接字符串、API 密钥等。这个模块包含应用程序的配置类或文件，用于管理和访问配置参数。

### Meesage层
- 一层用于定义项目中使用的消息类型和相关的消息处理。
### IntegrationTests 层
- 这是用于执行集成测试的层次。 可以编写和运行测试用例来验证不同模块之间的集成是否正常工作，例如测试 API 的端到端功能
#### UnitTests 层
- 这是用于执行单元测试的层次,你可以编写和运行测试用例来验证各个模块的独立单元是否按预期工作，例如测试业务逻辑层和数据访问层的功能


## 知识点
### 概念
#### 1.实体对象：具有唯一标识，能单独存在且可变化的对象 
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/f73712c2-66fc-4dce-a7ff-4a65c7fbc12c)
- Id 属性表示 Company 的唯一标识，类型为 Guid
- Name、Email、Address、Phone 和 CreatedDate 这些属性具有私有的 setter，这意味着它们只能在构造函数中进行赋值，并且在对象创建后不能被外部更改。
- 有一个公共构造函数，接受 name、email、address 和 phone 参数，用于创建一个新的 Company 对象。在构造函数内部，为 Id 属性生成一个新的唯一标识，并为其他属性赋予传入的参数值。
- AddWarehouse 方法：该方法接受参数用于创建一个新的 Warehouse 对象，并将其关联到当前的 Company 对象。通过使用 Id 属性作为参数，新的 Warehouse 对象与当前 Company 对象建立了关联关系。
- Company 类在 DDD 项目中是一个具有唯一标识、封装状态和行为的实体。它代表了业务领域中的一个具体概念，并提供了创建关联实体的方法。
#### 2.聚合：多个对象的集合，对外是一个整体
- 在上述代码中，Company类可以看作一个聚合，它包含了一组相关联的属性和方法。聚合通过封装一组具有内聚性的领域对象来表示某个业务概念，而Company类正是通过封装了与公司相关的属性和方法来表示一个公司实体。

#### 3.聚合根：聚合中可代表整个业务操作的实体对象，通过它提供对外访问操作，它维护聚合内部的数据一致性，它是聚合中对象的管理者
- Company类是一个聚合根。聚合根是聚合内具有全局唯一标识的对象，作为整个聚合的入口，通过聚合根对聚合进行操作和访问。
- Company类中，Id属性用于唯一标识一个公司实体，并且AddWarehouse方法用于创建并关联Warehouse对象，表明Company类是整个聚合的入口。
  
#### 4.值对象：不能单独存在或在逻辑层面单独存在无意义，且不可变化的对象
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/befe069b-37ba-4038-878f-d02e41c5b748)
- 这个类在领域驱动设计 (Domain-Driven Design, DDD) 中的职责是实现值对象（Value Object）的基本功能.
- 该类定义了值对象的相等比较方式和哈希码生成方式，以及重载了相等性运算符（== 和 !=）。
- 它使用了反射来获取值对象的属性和字段，并根据这些属性和字段的值来判断两个值对象是否相等。如果所有属性和字段的值都相等，则认为两个值对象相等。
- 还重写了 Equals 方法和 GetHashCode 方法。Equals 方法使用 GetProperties 和 GetFields 方法来获取属性和字段的列表，并逐一比较两个对象的属性和字段是否相等。
- GetHashCode 方法则根据对象的类型和属性值生成哈希码，用于在集合中查找和比较值对象。
- 值对象在 DDD 中常用于表示领域模型中的属性或组合对象，通过值对象的不可变性来保证领域模型的一致性和完整性。
- 这个类提供了一个通用的基类，使得开发人员可以方便地创建自定义的值对象，并重写相等比较和哈希码生成逻辑。

## 技术栈

- **语言**: C#
- **框架**: .NET 6 Api
- **持久化**: MySQL
- **测试**: IntegrationTests, UnitTetst (目前只是一个空框架 还未开始补充)
