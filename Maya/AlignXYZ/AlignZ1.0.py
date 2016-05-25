#AlignZ.py
import maya.cmds as cmds

firstVtxIndexY = 2
secondVtxIndexY = 4

cmds.selectPref(isp=False)

s = cmds.ls(fl=1, os=True)
firstObj = s[0]
secondObj = s[1]
 
vertPos1 = cmds.xform(firstObj, query=True, worldSpace=True, translation=True)
vertPos2 = cmds.xform(secondObj, query=True, worldSpace=True, translation=True)

vtx1X = vertPos1[0]

vtx1Y = vertPos1[1]

vtx1Z = vertPos1[2]


vtx2X = vertPos2[0]

vtx2Y = vertPos2[1]

vtx2Z = vertPos2[2]

cmds.xform(firstObj, a=False, t=(vtx1X, vtx1Y, vtx2Z), ws=True)
