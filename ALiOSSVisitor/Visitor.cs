using System;
using System.Text;
using System.IO;
using Aliyun.OSS;

namespace ALiOSS
{
    public class OSSVisitor
    {
        public OSSVisitor(string endpoint, string accessKeyId, string accessKeySecret)
        {
            m_endpoint = endpoint;
            m_accessKeyId = accessKeyId;
            m_accessKeySecret = accessKeySecret;

            m_client = new OssClient(m_endpoint, m_accessKeyId, m_accessKeySecret);
        }

        public void SetBucket(string bucket)
        {
            m_bucket = bucket;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="objName"> 在Bucket中的名字 </param>
        /// <param name="filePath"> 上传文件路径（包含文件名） </param>
        public void PutFile(string objName, string filePath)
        {
            if (String.IsNullOrEmpty(m_bucket))
            {
                Console.WriteLine("not set bucket !");
                return;
            }

            if(File.Exists(filePath) == false)
            {
                Console.WriteLine("file not exists ! Path = {0}", filePath);
                return;
            }
            try
            {
                m_client.PutObject(m_bucket, objName, filePath);
                Console.WriteLine("put file succ ! Bucket={0}, FilePath={1}", m_bucket, filePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine("put file fail ! Bucket={0}, FilePath={1}, ErrMsg={2}", m_bucket, filePath, ex.Message);
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="objName"> 在Bucket中的名字 </param>
        /// <param name="savePath"> 文件下载下来保存路径 </param>
        public void DownloadFile(string objName, string savePath)
        {
            if (String.IsNullOrEmpty(m_bucket))
            {
                Console.WriteLine("not set bucket !");
                return;
            }

            if (Directory.Exists(savePath) == false)
            {
                try
                {
                    Directory.CreateDirectory(savePath);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("the save path illegal !");
                    return;
                }
            }
            
            try
            {
                var _obj = m_client.GetObject(m_bucket, objName);
                using (var requestStream = _obj.Content)
                {
                    byte[] _buf = new byte[1024];
                    string fileFullPath = savePath + objName;
                    var fs = File.Open(fileFullPath, FileMode.OpenOrCreate);
                    var len = 0;
                    while ((len = requestStream.Read(_buf, 0, 1024)) != 0)
                    {
                        fs.Write(_buf, 0, len);
                    }
                    fs.Close();

                    Console.WriteLine("download file succ ! Bucket={0}, FilePath={1}", m_bucket, fileFullPath);
                } 
            }
            catch(Exception ex)
            {
                Console.WriteLine("download fail : ObjectName={0}, SavePath={1} - \n    ErrorMsg={2}", objName, savePath, ex.Message);
            }
        }

        private string m_endpoint;
        private string m_bucket;
        private string m_accessKeyId;
        private string m_accessKeySecret;
        private OssClient m_client;
    }
}
