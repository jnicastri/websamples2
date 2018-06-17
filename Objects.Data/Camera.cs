using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Data.Foundation;
using Objects.Data.DTO;
using Objects.Data.Attributes;

namespace Objects.Data
{
    public class Camera : MockableDatabaseObject<Camera>, IDbComittable, IWebDTOable<WebDTO.Camera>
    {
        #region Members

        [MockableInt32(Value=150)]
        public int CameraId { get; private set; }

        [MockableInt32(IsMockable =false)]
        public int CameraNumber { get; set; }

        [MockableString(Value="Axis Super-Dupa Camera")]
        public string CameraName { get; set; }

        [MockableString(Value="Location 1")]
        public string LocationName { get; set; }

        #endregion

        #region .ctors

        public Camera() { }

        public Camera(int cameraId)
        {
            this.CameraId = cameraId;
            Load();
        }

        #endregion

        #region IDbCommittable

        public List<SqlParameter> GetSqlParameters(string prefix = "")
        {

            return null;
        }

        public void Save()
        {
            // TODO: 
            // Call GetSqlParameters
            // Pass Params into a Sproc to upsert()
            // If 'DatabaseLoaded is false - its an insert, if true its an update.
            throw new NotImplementedException();
        }

        #endregion

        #region DatabaseObject

        protected override void Load()
        {
            // TODO: 
            // Call Sproc to get Camera
            // Pass Reader into PopulateFromReader()
            throw new NotImplementedException();
        }

        public override void PopulateFromReader(SqlDataReader reader, string prefix = "")
        {
            if (reader[prefix + "CameraId"] != DBNull.Value)
                this.CameraId = Int32.Parse(reader[prefix + "CameraId"].ToString());

            if (reader[prefix + "CameraNumber"] != DBNull.Value)
                this.CameraNumber = Int32.Parse(reader[prefix + "CameraNumber"].ToString());

            this.CameraName = reader[prefix + "CameraName"].ToString();
            this.LocationName = reader[prefix + "Location"].ToString();

            this.DatabaseLoaded = true;
        }

        #endregion

        #region IWebDTOable

        public WebDTO.Camera ToWebDTO()
        {
            return new WebDTO.Camera()
            {
                CameraId = this.CameraId,
                CameraName = this.CameraName?.Trim(),
                CameraNumber = this.CameraNumber,
                LocationName = this.LocationName?.Trim()
            };
        }

        #endregion

    }
}
