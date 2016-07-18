static IEnumerable<string> ParseResourceAsInputLines(string resourceName = "LeftRotation.testcase0.txt")
    {
        using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (var streamReader = new StreamReader(stream))
                while (streamReader.Peek() >= 0)
                    yield return streamReader.ReadLine();
    }