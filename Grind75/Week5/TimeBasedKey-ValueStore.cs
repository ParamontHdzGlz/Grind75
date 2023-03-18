using Grind75.Week2;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week5
{
    public class TimeMap
    {

        private Dictionary<string, List<(int timestamp, string value)>> _timeMap;

        public TimeMap()
        {
            _timeMap = new Dictionary<string, List<(int timestamp, string value)>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (_timeMap.ContainsKey(key))
            {
                _timeMap[key].Add((timestamp, value));
            }
            else
            {
                _timeMap.Add(key, new List<(int timestamp, string value)> { (timestamp, value) });
            }
            //Console.WriteLine($"### SET ###");
            //Console.WriteLine($"key: {key}, list: {string.Join(",", _timeMap[key])}");
        }

        public string Get(string key, int timestamp)
        {
            if (!_timeMap.ContainsKey(key)) return string.Empty;
            return GetLatestValue(_timeMap[key], timestamp);
        }

        private string GetLatestValue(List<(int timestamp, string value)> list, int target)
        {
            int left = 0;
            int right = list.Count - 1;
            int middle = 0;

            while (left <= right)
            {
                middle = (left + right) / 2;
                //Console.WriteLine($"l: {left}, m: {middle}, r: {right}");
                //Console.WriteLine($"  timestamp[middle]: {list[middle].timestamp}, target:{target}");
                if (list[middle].timestamp == target)
                    return list[middle].value;
                else if (list[middle].timestamp < target)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            if (list[middle].timestamp > target)
            {
                return middle >= 1 ? list[middle - 1].value : "";
            }
            else
            {
                return list[middle].value;
            }
        }
    }
}
