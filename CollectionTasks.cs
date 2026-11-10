using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tasks1_5
{
    internal class CollectionTasks
    {
        public static List<int> RepeatEachElementTwice(
            List<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(
                    nameof(source));
            }

            List<int> result = new List<int>();
            int index = 0;

            while (index < source.Count)
            {
                result.Add(source[index]);
                result.Add(source[index]);

                index++;
            }

            return result;
        }


        public static LinkedList<int> ReverseBetweenMinMax(
            LinkedList<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(
                    nameof(source));
            }

            LinkedList<int> result = new LinkedList<int>();
            LinkedListNode<int> current = source.First;

            while (current != null)
            {
                result.AddLast(current.Value);
                current = current.Next;
            }

            if (result.Count < 3)
            {
                return result;
            }

            LinkedListNode<int> minimumNode = result.First;
            LinkedListNode<int> maximumNode = result.First;

            current = result.First;
            int index = 0;
            int minimumIndex = 0;
            int maximumIndex = 0;

            while (current != null)
            {
                if (current.Value < minimumNode.Value)
                {
                    minimumNode = current;
                    minimumIndex = index;
                }

                if (current.Value > maximumNode.Value)
                {
                    maximumNode = current;
                    maximumIndex = index;
                }

                current = current.Next;
                index++;
            }

            LinkedListNode<int> leftNode = null;
            LinkedListNode<int> rightNode = null;

            if (minimumIndex < maximumIndex)
            {
                leftNode = minimumNode.Next;
                rightNode = maximumNode.Previous;
            }
            else
            {
                leftNode = maximumNode.Next;
                rightNode = minimumNode.Previous;
            }

            int fragmentLength = Math.Abs(
                minimumIndex - maximumIndex) - 1;

            int swaps = fragmentLength / 2;
            int temporary = 0;

            while (swaps > 0)
            {
                temporary = leftNode.Value;
                leftNode.Value = rightNode.Value;
                rightNode.Value = temporary;

                leftNode = leftNode.Next;
                rightNode = rightNode.Previous;

                swaps--;
            }

            return result;
        }



        public static void AnalyzePartyVotes(
            HashSet<string> allParties,
            List<HashSet<string>> groupVotes)
        {
            if (allParties == null ||
                groupVotes == null ||
                groupVotes.Count == 0)
            {
                throw new ArgumentException(
                    "Некорректные исходные данные.");
            }

            HashSet<string> commonParties =
                new HashSet<string>(groupVotes[0]);

            HashSet<string> votedAtLeastOnce =
                new HashSet<string>();

            HashSet<string> votedOnlyOnce =
                new HashSet<string>();

            HashSet<string> newParties =
                new HashSet<string>();

            int index = 0;

            while (index < groupVotes.Count)
            {
                newParties.Clear();
                newParties.UnionWith(groupVotes[index]);

                newParties.ExceptWith(votedAtLeastOnce);

                votedOnlyOnce.ExceptWith(
                    groupVotes[index]);

                votedOnlyOnce.UnionWith(newParties);

                votedAtLeastOnce.UnionWith(
                    groupVotes[index]);

                index++;
            }

            index = 1;

            while (index < groupVotes.Count)
            {
                commonParties.IntersectWith(
                    groupVotes[index]);

                index++;
            }

            HashSet<string> notVoted =
                new HashSet<string>(allParties);

            notVoted.ExceptWith(votedAtLeastOnce);

            Console.WriteLine();
            Console.WriteLine("Голоса каждой группы:");

            index = 0;

            while (index < groupVotes.Count)
            {
                Console.WriteLine(
                    "Группа " + (index + 1) + ":");

                foreach (string party in groupVotes[index])
                {
                    Console.WriteLine(party);
                }

                index++;
            }

            Console.WriteLine();
            Console.WriteLine(
                "Партии, за которые проголосовали");
            Console.WriteLine("во всех группах:");

            foreach (string party in commonParties)
            {
                Console.WriteLine(party);
            }

            Console.WriteLine();
            Console.WriteLine(
                "Партии, за которые проголосовали");
            Console.WriteLine("только в одной группе:");

            foreach (string party in votedOnlyOnce)
            {
                Console.WriteLine(party);
            }

            Console.WriteLine();
            Console.WriteLine(
                "Партии, за которые не проголосовали:");

            foreach (string party in notVoted)
            {
                Console.WriteLine(party);
            }
        }


        public static HashSet<char> FindCharactersInOneWord(
            string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(
                    "Текст не должен быть пустым.");
            }

            string[] words = text.Split(
                (char[])null,
                StringSplitOptions.RemoveEmptyEntries);

            HashSet<char> result = new HashSet<char>();
            HashSet<char> currentWord =
                new HashSet<char>();

            HashSet<char> otherWords =
                new HashSet<char>();

            HashSet<char> repeatedCharacters =
                new HashSet<char>();

            HashSet<char> allCharacters =
                new HashSet<char>();

            int wordIndex = 0;
            int symbolIndex = 0;

            while (wordIndex < words.Length)
            {
                currentWord.Clear();
                symbolIndex = 0;

                while (symbolIndex < words[wordIndex].Length)
                {
                    char symbol = char.ToLowerInvariant(
                        words[wordIndex][symbolIndex]);

                    currentWord.Add(symbol);
                    symbolIndex++;
                }

                otherWords.Clear();
                otherWords.UnionWith(currentWord);
                otherWords.IntersectWith(allCharacters);

                repeatedCharacters.UnionWith(otherWords);
                allCharacters.UnionWith(currentWord);

                wordIndex++;
            }

            result.UnionWith(allCharacters);
            result.ExceptWith(repeatedCharacters);

            return result;
        }

        public static int FindExcellentScore(
        Dictionary<int, int> scoreCounts,
        int studentCount)
        {
            if (scoreCounts == null || studentCount <= 5)
            {
                throw new ArgumentException(
                    "Некорректные входные данные.");
            }

            int excellentCount = studentCount / 5;
            int highestScore = 100;
            int count = 0;
            int score = 100;
            int total = 0;
            int minimumScore = 0;

            while (highestScore >= 1 &&
                !scoreCounts.ContainsKey(highestScore))
            {
                highestScore--;
            }

            if (highestScore < 1)
            {
                throw new ArgumentException(
                    "Не найдены результаты учеников.");
            }

            count = scoreCounts[highestScore];

            if (count > excellentCount)
            {
                return highestScore;
            }

            score = highestScore;

            while (score >= 1)
            {
                count = 0;
                scoreCounts.TryGetValue(score, out count);

                if (count > 0)
                {
                    if (total + count > excellentCount)
                    {
                        break;
                    }

                    total += count;
                    minimumScore = score;

                    if (total == excellentCount)
                    {
                        break;
                    }
                }

                score--;
            }

            return minimumScore;
        }

    }
}
