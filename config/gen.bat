set WORKSPACE=..
set LUBAN_DLL=%WORKSPACE%/Tools/Luban/Luban.dll
set CONF_ROOT=.

dotnet %LUBAN_DLL% ^
    -t client ^
    -c cs-bin ^
    -d json ^
    -d bson ^
    -d bin ^
    -d bin-offset ^
    --conf %CONF_ROOT%/luban.conf ^
    -x cs-bin.outputCodeDir=%WORKSPACE%/unity/Assets/Config/Scripts/Config/Gen^
    -x json.outputDataDir=output_data/json ^
    -x bson.outputDataDir=output_data/bson ^
    -x bin-offset.outputDataDir=output_data/bin-offset ^
    -x bin.outputDataDir=output_data/bin ^
    -x tableImporter.filePattern="(.*)" ^
    -x tableImporter.tableNameFormat="{0}Table" ^
    -x tableImporter.valueTypeNameFormat="{0}Config"
    --customTemplateDir=%CONF_ROOT%/Templates
    
    

pause