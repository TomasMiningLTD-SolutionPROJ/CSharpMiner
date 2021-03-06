﻿/*  Copyright (C) 2014 Colton Manville
    This file is part of CSharpMiner.

    CSharpMiner is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    CSharpMiner is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with CSharpMiner.  If not, see <http://www.gnu.org/licenses/>.*/

using CSharpMiner.Interfaces;
using CSharpMiner.ModuleLoading;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSharpMiner.DeviceLoader
{
    [DataContract]
    public abstract class USBDeviceLoader : IDeviceLoader
    {
        [DataMember(Name = "ports", IsRequired=true)]
        [MiningSetting(ExampleValue = "[\"/dev/ttyUSB0\", \"/dev/ttyUSB1\", \"COM1\"]", Optional = false, Description = "List of ports devices are connected to. Linux /dev/tty* and Windows COM*")]
        public string[] Ports { get; set; }

        [DataMember(Name = "timeout")]
        [MiningSetting(ExampleValue = "60", Optional = true, Description = "Number of seconds to wait without response before restarting the device.")]
        public int WatchdogTimeout { get; set; }

        [DataMember(Name = "poll")]
        [MiningSetting(ExampleValue = "50", Optional = true, Description = "Milliseconds the thread waits before looking for incoming data. A larger value will decrease the processor usage but shares won't be submitted right away.")]
        public int PollFrequency { get; set; }

        public abstract IEnumerable<IMiningDevice> LoadDevices();
    }
}
