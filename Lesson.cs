using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Lesson
/// </summary>
public class Lesson
{

    public int LessonID;
    public int InstructorID;
    public int ClassID;

    public Lesson()
    {
    LessonID = 0;
    InstructorID = 0;
    ClassID = 0;
    }

    public Lesson(int LID, int IID, int CID)
    {
        LessonID = LID;
        InstructorID = IID;
        ClassID = CID;
    }

    public int getLessonID()
    {
        return LessonID;
    }

    public int getInstructorID()
    {
        return InstructorID;
    }

    public int getClassID()
    {
        return ClassID;
    }
	
}