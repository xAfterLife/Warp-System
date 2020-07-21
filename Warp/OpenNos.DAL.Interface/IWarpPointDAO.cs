using OpenNos.Data;
using System.Collections.Generic;

namespace OpenNos.DAL.Interface
{
    public interface IWarpPointDAO
    {
        #region Methods

        WarpPointDTO Insert(WarpPointDTO warpPoint);

        IEnumerable<WarpPointDTO> LoadAll();

        WarpPointDTO LoadById(short warppointID);

        IEnumerable<WarpPointDTO> LoadFromName(string name);

        #endregion
    }
}