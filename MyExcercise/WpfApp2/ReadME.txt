https://stackoverflow.com/questions/23153155/named-mutex-with-await
https://codereview.stackexchange.com/questions/115836/implementing-an-asynchronous-mutex-in-c

您必须确保在某个线程上一致地访问互斥锁
所以Mutex用Thread
Task用SemaphoreSlim 
来实现同步





