https://docs.microsoft.com/zh-cn/dotnet/standard/io/memory-mapped-files?redirectedfrom=MSDN

持久化内存映射文件
持久化文件是与磁盘上的源文件相关联的内存映射文件。 当最后一个进程处理完文件时，数据保存到磁盘上的源文件中。 此类内存映射文件适用于处理非常大的源文件。
非持久化内存映射文件
非持久化文件是不与磁盘上的文件相关联的内存映射文件。 当最后一个进程处理完文件时，数据会丢失，且文件被垃圾回收器回收。 此类文件适合创建共享内存，以进行进程内通信 (IPC)。


1 从磁盘上的文件获取表示持久化内存映射文件的 MemoryMappedFile 对象。	MemoryMappedFile.CreateFromFile 方法。
2 获取表示非持久化内存映射文件的 MemoryMappedFile 对象（未与磁盘上的文件关联）。	MemoryMappedFile.CreateNew 方法/MemoryMappedFile.CreateOrOpen 方法。。

3 获取现有内存映射文件（持久化或非持久化）的 MemoryMappedFile 对象。	MemoryMappedFile.OpenExisting 方法。


非持久化内存映射文件:
ProgressA 创建MemoryMappedFile，进程A关闭后MemoryMappedFile随之消散,所以如果想要两个进程访问一个内存，
需要打开非持久化内存映射文件的进程保持打开状态，撑到第二个进程来访问
所以非持久化内存映射文件适合于两个不关闭的进程之间的通讯，如一个进程发起并等待消息回传
或者是多线程.
同时Mutex也是这样，创建的进程关闭之后Mutex也随之消散....(这点不确定????)




