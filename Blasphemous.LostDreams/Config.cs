﻿using Blasphemous.LostDreams.Items.Penitences;
using Blasphemous.LostDreams.Items.RosaryBeads;
using Blasphemous.LostDreams.Items.SwordHearts;

namespace Blasphemous.LostDreams;

/// <summary>
/// Stores configuration settings
/// </summary>
public class Config
{
    /// <summary> Properties for RB502 </summary>
    public RB502Config RB502 { get; set; } = new();

    /// <summary>
    /// Properties for RB504
    /// </summary>
    public RB504Config RB504 { get; set; } = new();

    /// <summary> Properties for HE501 </summary>
    public HE501Config HE501 { get; set; } = new();

    /// <summary> Properties for PE501 </summary>
    public PE501Config PE501 { get; set; } = new();
}
