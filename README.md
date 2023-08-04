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
![image](https://github.com/dickens1998/ComapnyServer/assets/61829821/4369a616-2778-438d-8667-b915e85f732c)

   
#### Application（应用）: 层协调领域对象之间的交互，处理用户的请求，并调用适当的领域服务来执行业务逻辑。
#### Data(数据):Data 模块用于处理数据访问和持久化的相关逻辑
#### Domain(领域): 是整个核心层的核心，它包含了应用程序的核心业务逻辑和领域模型。模块定义了领域的概念、实体、值对象、聚合根以及领域服务等.
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

  
过将不同的组件划分到不同的模块中，Infrastructure 层实现了对不同领域概念和技术实现的组织和管理。DataAccessModule 和 MySqlConnectionFactory 提供了与数据访问相关的功能，
CompanyRepository 和 DomainEventsDispatcher 则涉及到与领域对象的交互.DomainModule 配置领域层组件，SpecificationExtensions 提供了领域规约的支持。
Mediator 和 MediatorExtensions 是为了解耦领域对象之间的交互而引入的。
这种分层和组织的方式有助于保持代码的可维护性和可测试性，同时也便于团队成员理解和修改代码。

  

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
- 个类还重写了 Equals 方法和 GetHashCode 方法。Equals 方法使用 GetProperties 和 GetFields 方法来获取属性和字段的列表，并逐一比较两个对象的属性和字段是否相等。
- GetHashCode 方法则根据对象的类型和属性值生成哈希码，用于在集合中查找和比较值对象。
- 值对象在 DDD 中常用于表示领域模型中的属性或组合对象，通过值对象的不可变性来保证领域模型的一致性和完整性。
- 这个类提供了一个通用的基类，使得开发人员可以方便地创建自定义的值对象，并重写相等比较和哈希码生成逻辑。

## 技术栈

- **语言**: C#
- **框架**: .NET 6 Api
- **持久化**: MySQL
- **测试**: IntegrationTests, UnitTetst (目前只是一个空框架 还未开始补充)
