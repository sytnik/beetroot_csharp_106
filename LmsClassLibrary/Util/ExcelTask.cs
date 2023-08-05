using LmsClassLibrary.Model;
using NPOI.SS.UserModel;

namespace LmsClassLibrary.Util;

public static class ExcelTask
{
    public static List<ExcelGroup> ParseGroups()
    {
        var workbook = WorkbookFactory.Create("groups.xls");
        var sheet = workbook.GetSheetAt(0);
        var groups = new List<ExcelGroup>();
        for (var i = 1; i < sheet.LastRowNum - 1; i++)
        {
            var departmentId = int.Parse(sheet.GetRow(i).GetCell(0).StringCellValue);
            var groupName = sheet.GetRow(i).GetCell(2).StringCellValue;
            var specialtyId = int.Parse(sheet.GetRow(i).GetCell(3)
                .StringCellValue.Split(";").ElementAt(0));
            var specialtyName = sheet.GetRow(i).GetCell(4).StringCellValue;
            var course = int.Parse(sheet.GetRow(i).GetCell(8).StringCellValue);
            groups.Add(new ExcelGroup(groupName, departmentId / 100, departmentId,
                specialtyId, specialtyName, course));
        }

        var startId = 1;
        groups.ForEach(group => group.Id = startId++);
        return groups.OrderBy(group => group.Name).ToList();
    }

    public static List<ExcelGroup> ParseGroupsParallel()
    {
        var workbook = WorkbookFactory.Create("groups.xls");
        var sheet = workbook.GetSheetAt(0);
        var groups = new List<ExcelGroup>();
        Parallel.For(1, sheet.LastRowNum - 1, i =>
        {
            var departmentId = int.Parse(sheet.GetRow(i).GetCell(0).StringCellValue);
            var groupName = sheet.GetRow(i).GetCell(2).StringCellValue;
            var specialtyId = int.Parse(sheet.GetRow(i).GetCell(3)
                .StringCellValue.Split(";").ElementAt(0));
            var specialtyName = sheet.GetRow(i).GetCell(4).StringCellValue;
            var course = int.Parse(sheet.GetRow(i).GetCell(8).StringCellValue);
            lock (groups)
                groups.Add(new ExcelGroup(groupName, departmentId / 100, departmentId,
                    specialtyId, specialtyName, course));
        });

        var startId = 1;
        groups.ForEach(group => group.Id = startId++);
        return groups.OrderBy(group => group.Name).ToList();
    }
}