using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using d7p4n4Namespace.Algebra.Class;
using d7p4n4Namespace.Final.Class;
using d7p4n4Namespace.Context.Class;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace d7p4n4Namespace.EFMethods.Class
{
    public class Ac4yJSONObjectEntityMethods : Ac4yJSONObjectAlgebra
    {
		public string serverName { get; set; }
		public string baseName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public Ac4yJSONObjectEntityMethods() { }

        public Ac4yJSONObjectEntityMethods(string sName, string newBaseName, string uName, string pwd)
        {
			serverName = sName;
            baseName = newBaseName;
            userName = uName;
            password = pwd;

            AllContext context = new AllContext(serverName, baseName, userName, password);
            context.Database.EnsureCreated();
        }

        public Ac4yJSONObject findFirstById(int id)
        {
            Ac4yJSONObject a = null;

            using (var ctx = new AllContext(serverName, baseName, userName, password))
            {
                var query = ctx.Ac4yJSONObjects
                                .Where(ss => ss.id == id)
                                .FirstOrDefault<Ac4yJSONObject>();

                a = query;
            }
            return a;
        }
		
		public Ac4yJSONObject LoadJSONById(int id)
        {
			Ac4yJSONObject a = null;

            using (var ctx = new AllContext(serverName, baseName, userName, password))
            {
                var query = ctx.Ac4yJSONObjects
                                .Where(ss => ss.id == id)
                                .FirstOrDefault<Ac4yJSONObject>();

                a = query;
            }

            string xml = a.serialization;

            Ac4yJSONObject aResult = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Ac4yJSONObject));

            StringReader reader = new StringReader(xml);
            aResult = (Ac4yJSONObject)serializer.Deserialize(reader);
            reader.Close();

            return aResult;
        }
		
	public void addNew(Ac4yJSONObject _Ac4yJSONObject)
	{
		using (var ctx = new AllContext(serverName, baseName, userName, password))
            {
                ctx.Ac4yJSONObjects.Add(_Ac4yJSONObject);

                ctx.SaveChanges();
            }
	}
	
	    public void SaveWithJSON(Ac4yJSONObject _Ac4yJSONObject)
        {
            string xml = "";

            XmlSerializer serializer = new XmlSerializer(typeof(Ac4yJSONObject));
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);

            serializer.Serialize(xmlWriter, _Ac4yJSONObject);

            xml = stringWriter.ToString();

            _Ac4yJSONObject.serialization = xml;

			using (var ctx = new AllContext(serverName, baseName, userName, password))
            {
                ctx.Ac4yJSONObjects.Add(_Ac4yJSONObject);

                ctx.SaveChanges();
            }
        }
    }
}
