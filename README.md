# yaml2json
Command line version of how SpecGen converts OpenAPI YAML files to JSON.

### Note:
This is useful because SpecGen will only do this conversion after an XSLT transform (which isn't always necessary).

## Syntax:
```console
yaml2json.exe <yamlFilePath> <jsonFilePath>
```

## Example:
```console
yaml2json.exe commonDefs.yaml commonDefs.json
```
