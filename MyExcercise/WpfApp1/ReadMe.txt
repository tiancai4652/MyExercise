https://docs.microsoft.com/zh-cn/dotnet/standard/io/memory-mapped-files?redirectedfrom=MSDN

�־û��ڴ�ӳ���ļ�
�־û��ļ���������ϵ�Դ�ļ���������ڴ�ӳ���ļ��� �����һ�����̴������ļ�ʱ�����ݱ��浽�����ϵ�Դ�ļ��С� �����ڴ�ӳ���ļ������ڴ���ǳ����Դ�ļ���
�ǳ־û��ڴ�ӳ���ļ�
�ǳ־û��ļ��ǲ�������ϵ��ļ���������ڴ�ӳ���ļ��� �����һ�����̴������ļ�ʱ�����ݻᶪʧ�����ļ����������������ա� �����ļ��ʺϴ��������ڴ棬�Խ��н�����ͨ�� (IPC)��


1 �Ӵ����ϵ��ļ���ȡ��ʾ�־û��ڴ�ӳ���ļ��� MemoryMappedFile ����	MemoryMappedFile.CreateFromFile ������
2 ��ȡ��ʾ�ǳ־û��ڴ�ӳ���ļ��� MemoryMappedFile ����δ������ϵ��ļ���������	MemoryMappedFile.CreateNew ����/MemoryMappedFile.CreateOrOpen ��������

3 ��ȡ�����ڴ�ӳ���ļ����־û���ǳ־û����� MemoryMappedFile ����	MemoryMappedFile.OpenExisting ������


�ǳ־û��ڴ�ӳ���ļ�:
ProgressA ����MemoryMappedFile������A�رպ�MemoryMappedFile��֮��ɢ,���������Ҫ�������̷���һ���ڴ棬
��Ҫ�򿪷ǳ־û��ڴ�ӳ���ļ��Ľ��̱��ִ�״̬���ŵ��ڶ�������������
���Էǳ־û��ڴ�ӳ���ļ��ʺ����������رյĽ���֮���ͨѶ����һ�����̷��𲢵ȴ���Ϣ�ش�
�����Ƕ��߳�.
ͬʱMutexҲ�������������Ľ��̹ر�֮��MutexҲ��֮��ɢ....(��㲻ȷ��????)




