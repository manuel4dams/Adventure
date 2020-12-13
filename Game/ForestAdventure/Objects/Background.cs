<<<<<<< HEAD
﻿using Framework.Development.Components;
=======
﻿using Framework.Components;
>>>>>>> master
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class Background : GameObject
    {
        public Background()
        {
            // TODO add background
            transform.position = new Vector2(0f, 0f);
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 8f));
#endif
        }
    }
}