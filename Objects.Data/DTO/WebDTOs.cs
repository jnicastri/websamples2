using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Data.Foundation;

namespace Objects.Data.DTO
{
    public class WebDTO
    {
        public class Camera : IDTO
        {
            public int CameraId { get; set; }
            public int CameraNumber { get; set; }
            public string CameraName { get; set; }
            public string LocationName { get; set; }
        }

        public class CameraManager : IDTO
        {
            public int CameraManagerId { get; set; }
            public string ServerName { get; set; }
            public List<WebDTO.Camera> Cameras { get; set; }
        }
    }
}
