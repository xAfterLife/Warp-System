using OpenNos.Domain;
using System;

namespace OpenNos.Data
{
    [Serializable]
    public class WarpPointDTO
    {
        #region Properties

        public short WarpPointID { get; set; }

        public string Name { get; set; }

        public AuthorityType Authority { get; set; }

        public short MapId { get; set; }

        public short MapX { get; set; }

        public short MapY { get; set; }

        #endregion
    }
}
