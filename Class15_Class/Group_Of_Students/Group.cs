﻿using Group_Of_Students;
using System;

namespace GroupOfStudents
{
    class Group // TODO: Add search by Name, Id, EnterDate.
    {
        #region Constants

        private const byte STUDENTS_AMOUNT = 10;
        private const byte DELETED_STUDENT = 1;

        #endregion

        #region Private Data //TODO: Add Gorup Id. UnicueName property.

        private Student[] _students;
        private int _countOfStudents;

        #endregion

        #region Properties

        public OperationStatus LastOperationStatus { get; private set; }

        public int AmountOfStudents
        {
            get { return _countOfStudents; }
        }

        #endregion

        #region Accessors

        public Student GetStudentByPosition(int index)
        {
            return new Student(_students[index]);
        }

        #endregion

        #region CRUD Operations

        public void AddStudent(Student person)
        {
            if (_countOfStudents >= _students.Length)
            {
                Array.Resize(ref _students, _students.Length + (_students.Length * 2));
            }

            _students[_countOfStudents] = new Student(person);
            ++_countOfStudents;
        } 

        public void EditStudent(Student person, int index) // TODO: Edit by Id.
        {
            index -= 1; // Adjust index // It's not here! Before call!!
            if (index < 0 || index > _students.Length)
            {
                return; // Enum error.
            }

            _students[index] = new Student(person);
        }

        public void DeleteStudent(int index) // TODO: Delete by Id.
        {
            index -= 1; // Adjust index
            if (index < 0 || index > _students.Length)
            {
                return; // Enum error.
            }

            for (int i = index; i < _countOfStudents - 1; i++)
            {
                _students[i] = _students[i + 1];
            }

            _countOfStudents -= DELETED_STUDENT;
        }


        public int SearchByName(string name)
        {
            int result = 0;

            LastOperationStatus = OperationStatus.Not_Found;

            for (int i = 0; i < _countOfStudents; i++)
            {
                if (_students[i].Name == name)
                {
                    result = i;
                    LastOperationStatus = OperationStatus.Ok;
                }
            }

            return result;
        }


        #endregion


        #region Constructors 

        public Group(int capacity=STUDENTS_AMOUNT) // TODO: From Students[] to Group
        {
            _students = new Student[capacity];
            _countOfStudents = 0;
        }

        public Group(Group source)
        {
            _students = GetFullCopy(source._students);
            _countOfStudents = source._countOfStudents;
        }

        public Group(Student[] input)
        {
            _students = GetFullCopy(input);
            //_countOfStudents = ???;
        }

        #endregion

        #region Utilits

        public double GetGPA() // Grade Point Average.
        {
            double gpa = 0;

            for (int i = 0; i < _countOfStudents; i++)
            {
                gpa += _students[i].GetGPA();
            }

            return gpa / _countOfStudents;
        }

        private Student[] GetFullCopy(Student[] source)
        {
            Student[] destination = new Student[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = new Student(source[i]);
            }

            return destination;
        }

        #endregion
    }
}
