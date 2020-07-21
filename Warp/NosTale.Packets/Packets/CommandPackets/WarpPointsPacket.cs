using OpenNos.Core;
using OpenNos.Domain;

namespace NosTale.Packets.Packets.CommandPackets
{
    [PacketHeader("$WarpPoints", PassNonParseablePacket = true, Authority = AuthorityType.User)]
    public class WarpPointsPacket : PacketDefinition
    {
        #region Methods

        public static string ReturnHelp() => "$WarpPoints";

        #endregion
    }
}