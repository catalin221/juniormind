using System;

namespace StudentCatalogue
{
    public class StudentsCatalogue
    {
        public Student[] Catalogue;

        public StudentsCatalogue(Student[] catalogue)
        {
            this.Catalogue = catalogue;
        }

        public void AddNewStudent(Student toAdd)
        {
            Student[] newCatalogue = new Student[Catalogue.Length + 1];
            for (int i = 0; i < Catalogue.Length; i++)
            {
                newCatalogue[i] = Catalogue[i];
            }

            newCatalogue[Catalogue.Length - 1] = toAdd;
            Catalogue = newCatalogue;
        }

        public string GetStudentByPosition(int position)
        {
            SortStudentsByGrade(Catalogue);
            return this.Catalogue[position - 1].Name;
        }

        public int GetStudentPositionByName(string name)
        {
            SortStudentsByGrade(Catalogue);
            for (int i = 0; i < Catalogue.Length; i++)
            {
                if (Catalogue[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        private void SortStudentsByGrade(Student[] students)
        {
            QuickSort(students, 0, students.Length - 1);
        }

        private void QuickSort(Student[] students, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            const int cutHalf = 2;
            int middle = (left + right) / cutHalf;
            Student temp = students[left];
            students[left] = students[middle];
            students[middle] = temp;
            int i = left;
            int j = right;
            int d = 0;
            while (i < j)
            {
                if (students[i].Grade > students[j].Grade)
                {
                    temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                    d = 1 - d;
                }

                i += d;
                j -= 1 - d;
            }

            QuickSort(students, left, i - 1);
            QuickSort(students, i + 1, right);
        }
    }
}
