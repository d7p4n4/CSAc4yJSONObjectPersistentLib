
using System;
using System.Collections.Generic;
using System.Linq;
using CSAc4yObjectService.Class;
using CSAc4yService.Class; 
using d7p4n4Namespace.EFMethods.Class;
using d7p4n4Namespace.Final.Class;

namespace d7p4n4Namespace.PersistentService.Class
{
    public class Ac4yJSONObjectPersistentService
    {
		public string serverName { get; set; }
		public string baseName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
		private Ac4yJSONObjectEntityMethods _Ac4yJSONObjectEntityMethods { get; set; }
		
		public Ac4yJSONObjectPersistentService() { }

        public Ac4yJSONObjectPersistentService(string sName, string newBaseName, string uName, string pwd)
        {
			serverName = sName;
            baseName = newBaseName;
            userName = uName;
            password = pwd;
            _Ac4yJSONObjectEntityMethods = new Ac4yJSONObjectEntityMethods(sName, newBaseName, uName, pwd);
        }

        public GetObjectResponse GetFirstById(int id)
        {
            var response = new GetObjectResponse();
            try
            {
                response.Object = (_Ac4yJSONObjectEntityMethods.findFirstById(id));
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.Message });
            }

            return response;
        }

        public GetObjectResponse GetFirstWithXML(int id)
        {
            var response = new GetObjectResponse();
            try
            {
                response.Object = (_Ac4yJSONObjectEntityMethods.LoadXmlById(id));
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.Message });
            }

            return response;
		}
		
		public GetObjectResponse SaveWithXml(Ac4yJSONObject _Ac4yJSONObject)
        {
            var response = new GetObjectResponse();
            try
            {
                _Ac4yJSONObjectEntityMethods.SaveWithXml(_Ac4yJSONObject);
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.Message });
            }

            return response;
        }
		
		public GetObjectResponse Save(Ac4yJSONObject _Ac4yJSONObject)
        {
            var response = new GetObjectResponse();
            try
            {
                _Ac4yJSONObjectEntityMethods.addNew(_Ac4yJSONObject);
                response.Result = new Ac4yProcessResult() { Code = "1" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = "-1", Message = exception.Message });
            }

            return response;
        }
    }
}
