Models - Only contain the data related to the application. Some data conversion methods are also ok here. But no business logic.

Services - Pure, stateless services, that only work with models and interfaces. Since they are stateless, they can be run from different threads. ALL business logic goes here, and here only.

Interfaces - Repository Interface specifications to interact with external systems (Databases, APIs, File systems, etc) for storage. Other interfaces can also be defined here (for example, external services, message queues, etc