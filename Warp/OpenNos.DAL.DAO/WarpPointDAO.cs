/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using OpenNos.Core;
using OpenNos.DAL.EF;
using OpenNos.DAL.EF.Helpers;
using OpenNos.DAL.Interface;
using OpenNos.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenNos.DAL.DAO
{
    public class WarpPointDAO : IWarpPointDAO
    {
        #region Methods

        public WarpPointDTO Insert(WarpPointDTO warppoint)
        {
            try
            {
                using (OpenNosContext context = DataAccessHelper.CreateContext())
                {
                    WarpPoint entity = new WarpPoint();
                    Mapper.Mappers.WarpPointMapper.ToWarpPoint(warppoint, entity);
                    context.WarpPoint.Add(entity);
                    context.SaveChanges();
                    if (Mapper.Mappers.WarpPointMapper.ToWarpPointDTO(entity, warppoint))
                    {
                        return warppoint;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public IEnumerable<WarpPointDTO> LoadAll()
        {
            using (OpenNosContext context = DataAccessHelper.CreateContext())
            {
                List<WarpPointDTO> result = new List<WarpPointDTO>();
                foreach (WarpPoint entity in context.WarpPoint)
                {
                    WarpPointDTO dto = new WarpPointDTO();
                    Mapper.Mappers.WarpPointMapper.ToWarpPointDTO(entity, dto);
                    result.Add(dto);
                }
                return result;
            }
        }

        public WarpPointDTO LoadById(short warppointID)
        {
            try
            {
                using (OpenNosContext context = DataAccessHelper.CreateContext())
                {
                    WarpPointDTO dto = new WarpPointDTO();
                    if (Mapper.Mappers.WarpPointMapper.ToWarpPointDTO(context.WarpPoint.FirstOrDefault(i => i.Index.Equals(warppointID)), dto))
                    {
                        return dto;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }

        public IEnumerable<WarpPointDTO> LoadFromName(string name)
        {
            using (OpenNosContext context = DataAccessHelper.CreateContext())
            {
                List<WarpPointDTO> result = new List<WarpPointDTO>();
                foreach (WarpPoint entity in context.WarpPoint.Where(c => c.Name.Equals(name)))
                {
                    WarpPointDTO dto = new WarpPointDTO();
                    Mapper.Mappers.WarpPointMapper.ToWarpPointDTO(entity, dto);
                    result.Add(dto);
                }
                return result;
            }
        }

        #endregion
    }
}