using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQUI
{
    [Serializable]
    public class ManagedDirectory
    {
        #region properties

        /// <summary>
        /// 현재 오더가 활성화되어있는지 여부입니다.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 작업을 수행할 대상 폴더입니다.
        /// </summary>
        public string DepartureFolder { get; private set; }

        /// <summary>
        /// 작업물을 이동할 폴더입니다.
        /// </summary>
        public string DestinationFolder { get; private set; }

        /// <summary>
        /// 고급 작업에 사용되는 조건들입니다.
        /// </summary>
        public Option Option { get; private set; }

        public int WatcherIndex { get; set; }
        
        #endregion

        public ManagedDirectory(string departure, string destination, Option option)
        {
            this.Enabled = true;
            this.DepartureFolder = departure;
            this.DestinationFolder = destination;
            this.Option = option;
            WatcherIndex = -1;
        }
    }

    [Serializable]
    public class Option
    {
        #region properties

        /// <summary>
        /// 파일 확장자가 리스트에 등록된 문자열과 일치하는 경우에만 작업을 수행한다.
        /// 비어있을 경우엔 모든 확장자를 대상으로 작업을 수행한다.
        /// </summary>
        public List<string> FileExtensions { get; private set; }

        /// <summary>
        /// 파일명이 리스트에 등록된 문자열을 모두 포함하는 경우 작업을 수행한다.
        /// </summary>
        public List<string> IncludeStrings { get; private set; }

        /// <summary>
        /// 파일명이 리스트에 등록된 문자열을 하나 이상 포함하는 경우, 작업을 취소한다.
        /// </summary>
        public List<string> DecludeStrings { get; private set; }

        /// <summary>
        /// 파일명에 리스트에 등록된 문자열을 하나 이상 포함하는 경우 작업을 수행한다.
        /// </summary>
        public List<string> OptionStrings { get; private set; }

        /// <summary>
        /// 파일이 복사되는지 여부입니다. 거짓일경우 원본 파일을 삭제합니다.(이동)
        /// </summary>
        public bool isCopy { get; set; }

        /// <summary>
        /// 중복 파일의 처리 방식입니다.
        /// </summary>
        public DuplicateProcessing Duplicate { get; private set; }

        /// <summary>
        /// 하위 디렉터리도 포함해서 작업할것인지 여부입니다.
        /// </summary>
        public bool RootSerach { get; private set; }

        /// <summary>
        /// 실시간 감시 기능 여부
        /// </summary>
        public bool RealtimeWatch { get; private set; }

        #endregion

        public Option(string[] extensions, string[] includes, string[] decluides, string[] options, bool isCopy, DuplicateProcessing dp, bool root, bool realtimeWatch)
        {
            FileExtensions = extensions.ToList();
            IncludeStrings = includes.ToList();
            DecludeStrings = decluides.ToList();
            OptionStrings = options.ToList();
            this.isCopy = isCopy;
            Duplicate = dp;
            RootSerach = root;
            RealtimeWatch = realtimeWatch;
        }
    }

    public enum DuplicateProcessing { Overwrite, Renaming, None }
}
