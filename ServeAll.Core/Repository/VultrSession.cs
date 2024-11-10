using System;
using System.Data;
using ServeAll.Core.Helper;

namespace ServeAll.Core.Repository
{
    public sealed class VultrSession : IDisposable
    {

        public VultrSession()
        {
            try
            {
                _connection = ConStr.VultrConString();
                _connection.Open();
                _unitOfWrk = new UnitofWork(_connection);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ServerSettings.PopUpMessages(0, "Error Detected in Server Connection String!", "Connectivity Error");
            }
        }

        private readonly IDbConnection _connection;
        private readonly UnitofWork _unitOfWrk;
        public UnitofWork UnitofWrk => _unitOfWrk;

        public void Dispose()
        {
            _unitOfWrk.Dispose();
            _connection.Dispose();
        }
    }
}
