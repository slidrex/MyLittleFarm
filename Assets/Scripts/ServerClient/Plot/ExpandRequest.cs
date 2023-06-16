using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandRequest
{
    public long plotId;
    public bool horizontalExpand;

    public ExpandRequest(long plotId, bool horizontalExpand)
    {
        this.plotId = plotId;
        this.horizontalExpand = horizontalExpand;
    }
}
