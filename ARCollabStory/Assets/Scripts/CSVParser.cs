using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;

public class LocationRecord
{
    public int DirectionIndex { get; set; }
    public string MissionTypeInfo { get; set; }
    public string MissionStatus { get; set; }
    public double Latitude { get; set; }
    public double Longuitude { get; set; }
}

public class DialogueRecord
{
    public int Index { get; set; }
    public string Name { get; set; }
    public string Dialogue { get; set; }
}

public class BookRecord
{
    public int Page { get; set; }
    public int Index { get; set; }
    public string Story { get; set; }
}

public class PuzzleRecord
{
    public string PuzzleStory { get; set; }
    public string PuzzleInfo { get; set; }
    public int PuzzleIndex { get; set; }
}

public class CSVMethods
{
    public int ParseIntData(string dataValue)
    {
        if(int.TryParse(dataValue, out int result))
        {
            return int.Parse(dataValue);
        }

        Debug.LogError("int 데이터 파싱 실패");
        return -1;
    }

    public double ParseDoubleData(string dataValue)
    {
        if (double.TryParse(dataValue, out double result))
        {
            return double.Parse(dataValue);
        }

        Debug.LogError("double 데이터 파싱 실패");
        return -1;
    }
}
public static class CSVParser
{
    static CSVMethods _csvMethods = new CSVMethods();
    public static List<LocationRecord> GetLocationInfos()
    {
        TextAsset locationTextAsset = Resources.Load<TextAsset>("LocationsInfo");
        List<LocationRecord> locationRecords = new List<LocationRecord>();
        locationRecords.Add(null);
        using (StringReader csvString = new StringReader(locationTextAsset.text))
        {

            while(csvString.Peek() > -1)
            {
                string stringData = csvString.ReadLine();
                var dataValues = stringData.Split('|');
                LocationRecord parseData = new LocationRecord();
                parseData.DirectionIndex = _csvMethods.ParseIntData(dataValues[0]);
                parseData.MissionTypeInfo = dataValues[1];
                parseData.MissionStatus = dataValues[2];
                parseData.Latitude = _csvMethods.ParseDoubleData(dataValues[3]);
                parseData.Longuitude = _csvMethods.ParseDoubleData(dataValues[4]);
                locationRecords.Add(parseData);
            }
        }
        locationRecords.Remove(null);
        return locationRecords;
    }

    public static List<DialogueRecord> GetDialogueInfos()
    {
        TextAsset dialogueTextAsset = Resources.Load<TextAsset>("DialogueTest");
        List<DialogueRecord> dialogues = new List<DialogueRecord>();
        dialogues.Add(null);
        using (StringReader csvString = new StringReader(dialogueTextAsset.text))
        {
            while (csvString.Peek() > -1)
            {
                string stringData = csvString.ReadLine();
                var dataValues = stringData.Split('|');
                DialogueRecord parseData = new DialogueRecord();
                parseData.Index = _csvMethods.ParseIntData(dataValues[0]);
                parseData.Name = dataValues[1];
                parseData.Dialogue = dataValues[2];
                Debug.Log($"{parseData.Dialogue}");
                dialogues.Add(parseData);
            }
        }
        return dialogues;
    }

    public static (List<BookRecord>, List<PuzzleRecord>) GetBookInfos()
    {
        TextAsset storyTextAsset = Resources.Load<TextAsset>("StoryInfo");
        List<BookRecord> stories = new List<BookRecord>();
        List<PuzzleRecord> puzzles = new List<PuzzleRecord>();
        stories.Add(null);
        puzzles.Add(null);

        using (StringReader csvString = new StringReader(storyTextAsset.text))
        {
            while(csvString.Peek() > -1)
            {
                string stringData = csvString.ReadLine();
                var dataValues = stringData.Split('|');
                BookRecord bookData = new BookRecord();

                if (dataValues[2][0] == '\'')
                {
                    PuzzleRecord puzzleData = new PuzzleRecord();

                    puzzleData.PuzzleIndex = _csvMethods.ParseIntData(dataValues[4]);
                    puzzleData.PuzzleInfo = dataValues[3];
                    puzzleData.PuzzleStory = dataValues[2].Trim('\'');
                    string mosaicText = "";
                    int puzzleLength = puzzleData.PuzzleStory.Length;
                    for(int i = 1; i < puzzleLength; i++)
                    {
                        mosaicText += "0";
                    }
                    bookData.Story = mosaicText;

                    puzzles.Add(puzzleData);
                }

                bookData.Page = _csvMethods.ParseIntData(dataValues[0]);
                bookData.Index = _csvMethods.ParseIntData(dataValues[1]);
                if (bookData.Story == null) bookData.Story = dataValues[2]; 

                stories.Add(bookData);
            }
        }
        stories.Remove(null);
        puzzles.Remove(null);
        return (stories, puzzles);
    }
}