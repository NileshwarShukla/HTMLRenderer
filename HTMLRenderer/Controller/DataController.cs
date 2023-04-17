using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Http;

namespace OwinSelfhostSample
{
    
    public class DataController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
           string path= Path.Combine(Directory.GetCurrentDirectory(), "local", "File.csv");
           var table= ConvertCSVtoDataTable(path);
            
            return Ok(table);

        }

        public static string ConvertCSVtoDataTable(string strFilePath)
        {
            StringBuilder headers = new StringBuilder();
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
            
                //foreach (string header in headers)
                //{
                //    dt.Columns.Add(header);
                //}
                while (!sr.EndOfStream)
                {
                    headers.Append(string.Join(",",sr.ReadLine().Split(',')));
                    headers.Append(",");
                }

            }


            return headers.ToString(); 
        }
    }
}