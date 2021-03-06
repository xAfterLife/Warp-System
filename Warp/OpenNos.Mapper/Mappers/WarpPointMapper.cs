﻿using OpenNos.DAL.EF;
using OpenNos.Data;

namespace OpenNos.Mapper.Mappers
{
    public static class WarpPointMapper
    {
        #region Methods

        public static bool ToWarpPoint(WarpPointDTO input, WarpPoint output)
        {
            if (input == null)
            {
                return false;
            }

            output.WarpPointID = input.WarpPointID;
            output.Name = input.Name;
            output.MapId = input.MapId;
            output.MapX = input.MapX;
            output.MapY = input.MapY;
            output.Authority = input.Authority;

            return true;
        }

        public static bool ToWarpPointDTO(WarpPoint input, WarpPointDTO output)
        {
            if (input == null)
            {
                return false;
            }

            output.WarpPointID = input.WarpPointID;
            output.Name = input.Name;
            output.MapId = input.MapId;
            output.MapX = input.MapX;
            output.MapY = input.MapY;
            output.Authority = input.Authority;

            return true;
        }

        #endregion
    }
}
