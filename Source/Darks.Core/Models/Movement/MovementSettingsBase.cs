using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darks.Core.Models.Movement;
public class MovementSettingsBase : Model
{
    public string MoveForwardKey { get; set; }
    public string MoveBackwardKey { get; set; }
    public string MoveLeftKey { get; set; }
    public string MoveRightKey { get; set; }
    public string Crouch { get; set; }
}
