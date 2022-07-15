﻿using DoItFast.Application.Command.Gateway;
using DoItFast.Domain.Core.Abstractions.Dtos;
using DoItFast.Domain.Core.Attributes;
using DoItFast.Domain.Models.GatewayAggregate;

namespace DoItFast.Application.Dtos.Gateway
{
    [FullMap(typeof(GatewayCreateCommand.PeripheralDeviceModel))]
    public class PeripheralDeviceCreateRequestDto : IDto
    {
        /// <summary>
        /// Vendor.
        /// </summary>
        public string Vendor { get; set; }
        /// <summary>
        /// Status.
        /// </summary>
        public PeripheralDeviceStatusValues PeripheralDeviceStatusId { get; set; }
    }
}
