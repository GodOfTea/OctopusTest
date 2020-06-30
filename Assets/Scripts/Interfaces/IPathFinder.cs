using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathFinder
{
    IList<ICell> FindPathOnMap (ICell cellStart, ICell cellEnd, IMap map);
}
