
namespace ALiOSS
{
    class Test
    {
        public static void DownloadFile()
        {
            var visitor = new OSSVisitor("oss-cn-shanghai.aliyuncs.com", "LTAIZXB0giGjOwzX", "UnuGQBLQZwIsgCamezhOKDOxjt0Cw4");
            visitor.SetBucket("test-zjb");
            visitor.DownloadFile("test", @"E:\WorkStation\C#\AngelZ\ALiOSSVisitor\");
        }

        public static void PutFile()
        {
            var visitor = new OSSVisitor("oss-cn-shanghai.aliyuncs.com", "LTAIZXB0giGjOwzX", "UnuGQBLQZwIsgCamezhOKDOxjt0Cw4");
            visitor.SetBucket("test-zjb");
            visitor.PutFile("test", @"E:\WorkStation\C#\AngelZ\ALiOSSVisitor\");
        }
    }
}
