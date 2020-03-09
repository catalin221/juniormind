using System;

namespace StudentCatalogue
{
    public class StudentsCatalogue
    {
        private Student[] catalogue;

        public StudentsCatalogue(Student[] catalogue)
        {
            this.catalogue = catalogue;
        }

        public void AddNewStudent(Student toAdd)
        {
            Student[] newCatalogue = new Student[catalogue.Length + 1];
            for (int i = 0; i < catalogue.Length; i++)
            {
                newCatalogue[i] = catalogue[i];
            }

            newCatalogue[catalogue.Length - 1] = toAdd;
            catalogue = newCatalogue;
        }

        public Student[] GetStudents()
        {
            return this.catalogue;
        }

        public string GetStudentByPositionInRanking(int position)
        {
            SortStudentsByGrade(catalogue);
            return this.catalogue[position - 1].GetName();
        }

        public int GetStudentPositionByNameInRanking(string name)
        {
            SortStudentsByGrade(catalogue);
            for (int i = 0; i < catalogue.Length; i++)
            {
                if (catalogue[i].MatchName(name))
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
                if (students[i].GetArithmeticAverage() > students[j].GetArithmeticAverage())
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
