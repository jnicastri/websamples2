using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Data.Foundation;
using Objects.Data.Attributes;
using Objects.Data.DTO;
using System.Data.SqlClient;

namespace Objects.Data
{
    public class CameraManager : MockableDatabaseObject<CameraManager>, IDbComittable, IWebDTOable<WebDTO.CameraManager>
    {
        [MockableInt32(Value = 100)]
        public int CameraManagerId { get; private set; }

        [MockableString(Value = "HONVIDEOSVR1A")]
        public string ServerName { get; private set; }

        [MockableCollection(typeof(Camera), Size = 4)]
        public List<Camera> Cameras { get; set; }

        [MockableUserType(typeof(Camera))]
        public Camera Cam { get; set; }

        public CameraManager() { Cameras = new List<Camera>(); }

        public CameraManager(int cameraManagerId)
        {

        }

        protected override void Load()
        {
            throw new NotImplementedException();
        }

        public override void PopulateFromReader(SqlDataReader reader, string prefix = "")
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetSqlParameters(string prefix = "")
        {
            throw new NotImplementedException();
        }

        public WebDTO.CameraManager ToWebDTO()
        {
            throw new NotImplementedException();
        }
    }
}
