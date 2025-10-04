List<string> FindAllFiles(string directoryPath)
{
    return Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
        .Select(file => Path.GetRelativePath(directoryPath, file))
        .ToList();
}

var replacements = new[]
{
    //ORDER MATTERS
    new { Old = "com.example", New = "io.github.cooldev" }, //change mod package
    new { Old = "template", New = "coolmod" }, //change modid
    new { Old = "Template", New = "Cool Mod" }, //change mod display name
    //               ↕ <- Letter L is different case here
    new { Old = "TempLate", New = "CoolMod" }, //change mod init class and other places where mod name is in PascalCase
    new { Old = "AuthorExample", New = "CoolDev" }
};

var files = FindAllFiles(Directory.GetCurrentDirectory());

foreach (var file in files)
{
    var oldFile = file.Replace("\\", "/");
    var newFile = oldFile;
    Console.WriteLine("checking: " + oldFile);

    if (oldFile.StartsWith("."))
        continue;
    if (oldFile.Contains(".cs"))
        continue;
    if (oldFile.Contains(".git"))
        continue;
    if (oldFile.Contains(".gradle/"))
        continue;
    if (oldFile.Contains("build/"))
        continue;
    if (oldFile.Contains("LICENSE"))
        continue;
    if (oldFile.Contains("bin"))
        continue;
    if (oldFile.Contains("obj"))
        continue;

    var fileContent = File.ReadAllText(oldFile);

    foreach (var replacement in replacements)
    {
        fileContent = fileContent.Replace(replacement.Old, replacement.New);
        newFile = newFile.Replace(replacement.Old.Replace(".", "/"), replacement.New.Replace(".", "/"));
    }
    Console.WriteLine($"Moving \n\t< {oldFile} \n\t> {newFile}");
    File.Delete(oldFile);
    try
    {
        Directory.CreateDirectory(Path.GetDirectoryName(newFile));
    }
    catch { }
    ;
    File.WriteAllText(newFile, fileContent);
}