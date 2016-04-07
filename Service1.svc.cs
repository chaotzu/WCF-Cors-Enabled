using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcf.App
{    
    public class Service1 : IService1
    {
        public string Anymethod(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Employee[] GetEmployees()
        {
            return new Employee[] 
             {
                  new Employee() {Usuario="101",Correo="Empleado1",DeptName="iingen"},
                  new Employee() {Usuario="101",Correo="Empleado2",DeptName="iingen"},
                  new Employee() {Usuario="102",Correo="Empleado3",DeptName="iinngen"}
             };
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Employee[] Empleados()
        {
            return GetEmployees();
        }


        public string TestMethod(CompositeType value)
        {
            return string.Format("You entered: {0}", value.StringValue);
        }

        public String Upload(Stream Uploading)
        {
            String nombreArchivo = "";            
            nombreArchivo = "test.jpg";
            String savePath = @"c:\temp\uploads\";                 
            CargarArchivo upload = new CargarArchivo
            {                
                FilePath = Path.Combine(savePath, nombreArchivo)
            };

            int length = 0;
            try
            {
                using (FileStream writer = new FileStream(upload.FilePath, FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[4096000];
                    while ((readCount = Uploading.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        length += readCount;
                    }
                }

                upload.FileLength = length.ToString();
                String x = upload.FilePath;
                return x;
            }
            catch (Exception e)
            {
                return (e.ToString());
            }
        }
    }
}
