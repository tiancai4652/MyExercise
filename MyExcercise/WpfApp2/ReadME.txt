https://stackoverflow.com/questions/23153155/named-mutex-with-await
https://codereview.stackexchange.com/questions/115836/implementing-an-asynchronous-mutex-in-c

������ȷ����ĳ���߳���һ�µط��ʻ�����
����Mutex��Thread
Task��SemaphoreSlim 
��ʵ��ͬ��

1.
Mutex mut = new Mutex()
==��Mutex mut = new Mutex(false);

2.
Mutex mut = new Mutex(true);
==��Mutex mut = new Mutex()��mut.WaitOne();

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
 //��ǰ���Ѿ���������(��ǰʵ���Ѿ�������)
 }

5.
mut need dispose()

