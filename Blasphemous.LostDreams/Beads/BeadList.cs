﻿using System.Collections.Generic;

namespace Blasphemous.LostDreams.Beads;

internal class BeadList
{
    public IEnumerable<RosaryBead> Items { get; }

    public RosaryBead RB501 { get; }

    public BeadList(Config cfg)
    {
        Items = new RosaryBead[]
        {
            RB501 = new(new RB501()),
        };
    }
}
