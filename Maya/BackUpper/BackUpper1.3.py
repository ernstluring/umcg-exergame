#BackUpper.py

import maya.cmds as cmds
import functools

withoutExtension = 4

scnName = cmds.file(query=True, sceneName=True, shortName=True)
nameLength = len(scnName)
fileNumber = scnName[nameLength-withoutExtension]


def backUpper():
    print scnName
    
    scnNameWithoutNumber = scnName[:nameLength-withoutExtension]

    print "totalSceneName = %s" %scnName
    print "fileNumber = %s" %fileNumber
    print "SceneNameWithoutNumber = %s" %scnNameWithoutNumber

    newFileNumber = str(int(fileNumber)+1)
    newFileName = scnNameWithoutNumber+newFileNumber

    print "newFileName = %s" %newFileName

    cmds.file(rename = scnNameWithoutNumber+newFileNumber+".ma")
    cmds.file(save=True, type='mayaAscii')
    

def createSaveWindow():
    
    if cmds.window("windowID", exists=True):
       cmds.deleteUI("windowID")
    
    cmds.window("windowID", title="Save Scene", sizeable=False, resizeToFitChildren=True, h=200, w=200)
    cmds.rowColumnLayout(numberOfColumns=1, columnWidth=[(1,99)])
    cmds.text(label="Name Your Scene")
    inputField = cmds.textField(text="scene")
    
    cmds.button(label="Save", command=functools.partial(saveScene, inputField))
    cmds.button(label="Cancel", command = cancelSaveScene)
    
    cmds.showWindow()

def cancelSaveScene(*args):
    cmds.deleteUI("windowID")
    
def saveScene(sceneName, *args):   
   name = cmds.textField(sceneName, query=True, text=True)
   cmds.file(rename = name+"0.ma")
   cmds.file(save=True, type='mayaAscii')
   cmds.deleteUI("windowID")


if scnName != "":
    if fileNumber.isdigit():
        backUpper()
    else:
        print "fileNumber is no digit"
        cmds.file(rename = scnName[:nameLength-3]+"0.ma")
        cmds.file(save=True, type='mayaAscii')
else:
    createSaveWindow()
    
