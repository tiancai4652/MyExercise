https://stackoverflow.com/questions/23153155/named-mutex-with-await
https://codereview.stackexchange.com/questions/115836/implementing-an-asynchronous-mutex-in-c

您必须确保在某个线程上一致地访问互斥锁
所以Mutex用Thread
Task用SemaphoreSlim 
来实现同步

1.
Mutex mut = new Mutex()
==》Mutex mut = new Mutex(false);

2.
Mutex mut = new Mutex(true);
==》Mutex mut = new Mutex()；mut.WaitOne();

3.
if (mut.WaitOne(2000))
	{
		do something
	}
else
	{
		timeout do donothing
	}

4.
 mut = new Mutex(false, "MyMutex1", out creatNew);
 if(creatNew)
 else
 {
 //当前锁已经被创建了(当前实例已经运行了)
 }

5.
mut need dispose()

