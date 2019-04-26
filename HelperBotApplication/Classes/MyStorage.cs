using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ManageStudents
{
	public class MyStorage
	{
		internal static void SaveXML<T>(T students, string filename)
			{
				try
				{
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					FileStream stream;
					stream = new FileStream(filename, FileMode.Create);
					serializer.Serialize(stream, students);
					stream.Close();
				}
				catch (Exception e)
				{

				}
				//throw new NotImplementedException();
			}

		internal static T ReadXML<T>(String filename)
		{
			try
			{
				using (StreamReader sr = new StreamReader(filename))
				{
					XmlSerializer xmlser = new XmlSerializer(typeof(T));
					return (T)xmlser.Deserialize(sr); 
				}
			}
			catch(Exception e)
			{
				return default(T);
			}
		}
	}
}
