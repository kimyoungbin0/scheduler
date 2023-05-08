using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PriorityQueue2 //AT 기준
    {
        // 힙 트리는 배열로 관리할 수 있다.
        List<Process> _heap = new List<Process>();

        public void Push(Process data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;  // 추가한 노드의 위치. 힙의 맨 끝에서 시작.

            // 위로 도장 깨기 시작
            while (now > 0)
            {
                int next = (now - 1) / 2;  // 부모 노드
                if (_heap[now].AT > _heap[next].AT)  // 부모 노드와 비교
                    break;

                // 두 값을 서로 자리 바꿈
                Process temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치로 이동한다.
                now = next;
            }
        }

        public Process Pop()  // 최대값(루트)을 뽑아낸다.
        {
            // 반환할 데이터를 따로 저장
            Process ret = _heap[0];

            // 마지막 데이터를 루트로 이동시킨다.
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 아래로 도장 깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽 값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].AT > _heap[left].AT)
                    next = left;
                // 오른쪽 값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].AT > _heap[right].AT)
                    next = right;

                // 왼쪽/오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값 서로 자리 바꿈
                Process temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치로 이동한다.
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }
    class PriorityQueue //re_t(잔여 실행 시간) 기준
    {
        // 힙 트리는 배열로 관리할 수 있다.
        public List<Process> _heap = new List<Process>();

        public void Push(Process data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;  // 추가한 노드의 위치. 힙의 맨 끝에서 시작.

            // 위로 도장 깨기 시작
            while (now > 0)
            {
                int next = (now - 1) / 2;  // 부모 노드
                if (_heap[now].re_t > _heap[next].re_t)  // 부모 노드와 비교
                    break;

                // 두 값을 서로 자리 바꿈
                Process temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치로 이동한다.
                now = next;
            }
        }

        public Process Pop()  // 최대값(루트)을 뽑아낸다.
        {
            // 반환할 데이터를 따로 저장
            Process ret = _heap[0];

            // 마지막 데이터를 루트로 이동시킨다.
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 아래로 도장 깨기 시작
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽 값이 현재값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].re_t > _heap[left].re_t)
                    next = left;
                // 오른쪽 값이 현재값(왼쪽 이동 포함)보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].re_t > _heap[right].re_t)
                    next = right;

                // 왼쪽/오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값 서로 자리 바꿈
                Process temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치로 이동한다.
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }
    class Process
    {
        public int PID;
        public int AT;
        public int AAT;
        public int BT;
        public int WT;
        public int terminateTime;
        public int TT;
        public double NTT;
        public int re_t;
        public int RBT = 0;
        public bool fi_c = true;

        public Process(int PID, int AT, int BT)
        {
            this.PID = PID;
            this.AT = AT;
            this.AAT = AT;
            this.BT = BT;
            this.WT = 0;
            this.terminateTime = -1;
            this.re_t = BT;
        }
    }
    class Processor
    {
        public char core;
        public int time_q;
        public List<int> work = new List<int>();
        public double power = 0.0;
        public Processor(char co = 'e', int time_q = 0)
        {
            this.core = co;
            this.time_q = time_q;
        }
    }
    class Schedul
    {
        public int process_n;
        public int processor_n;
        public int[] wt;
        public int[] bt;
        public int[] tt;
        public double[] ntt;
        public double[] power;
        public int[] st_t;
        public int time_q;
        public Process[] process_arr;
        public Processor[] processor_arr;
        Queue<int> ready_q = new Queue<int>();
        //ready_q.Enqueue(값); 으로 값 넣고 ready_q.Dequeue();로 값 pop
        PriorityQueue ready_pq = new PriorityQueue();

        public Schedul(int pcsn, int pcsrn, int p_core, int[] ar_t, int[] b_t, int t_q = 0)
        {
            process_n = pcsn;
            processor_n = pcsrn;
            time_q = t_q;
            process_arr = new Process[pcsn];
            processor_arr = new Processor[pcsrn];
            wt = new int[pcsn];
            bt = new int[pcsn];
            tt = new int[pcsn];
            ntt = new double[pcsn];
            power = new double[pcsrn];
            st_t = new int[pcsn];
            for (int i = 0; i < pcsn; i++)
            {
                process_arr[i] = new Process(i, ar_t[i], b_t[i]);
            }
            for (int i = 0; i < p_core; i++)
            {
                processor_arr[i] = new Processor('p', t_q);
            }
            for (int i = p_core; i < pcsrn; i++)
            {
                processor_arr[i] = new Processor('e', t_q);
            }
        }

        public int find_empty_core(int time)
        {
            for (int i = 0; i < processor_n; i++)
            {
                if (processor_arr[i].work.Count <= time || -1 == processor_arr[i].work[time])
                {
                    return i;
                }
            }
            return -1;
        }
        public void CalWT() // TT-BT
        {
            for (int i = 0; i < process_n; i++)
            {
                wt[i] = process_arr[i].TT - process_arr[i].RBT;
            }
        }
        public void CalTT() // terminateTime - (st_t)
        {
            for (int i = 0; i < process_n; i++)
            {
                tt[i] = process_arr[i].terminateTime - process_arr[i].AT;
            }
        }
        public void CalNTT() // TT/BT
        {
            for (int i = 0; i < process_n; i++)
            {
                ntt[i] = process_arr[i].TT / process_arr[i].RBT;
            }
        }
        public void core_power()
        {
            for (int i = 0; i < processor_n; i++)
            {
                if (processor_arr[i].core == 'p')
                {
                    for (int j = 0; j < processor_arr[i].work.Count; j++)
                    {
                        if (j == 0)
                        {
                            if (processor_arr[i].work.ElementAt(j) != -1)
                            {
                                processor_arr[i].power += 3.5;
                            }
                        }
                        else
                        {
                            if (processor_arr[i].work.ElementAt(j) != -1 && processor_arr[i].work.ElementAt(j - 1) == -1)
                            {
                                processor_arr[i].power += 0.5;
                            }
                            if (processor_arr[i].work.ElementAt(j) != -1)
                            {
                                processor_arr[i].power += 3;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < processor_arr[i].work.Count; j++)
                    {
                        if (j == 0)
                        {
                            if (processor_arr[i].work.ElementAt(j) != -1)
                            {
                                processor_arr[i].power += 1.5;
                            }
                        }
                        else
                        {
                            if (processor_arr[i].work.ElementAt(j) != -1 && processor_arr[i].work.ElementAt(j - 1) == -1)
                            {
                                processor_arr[i].power += 0.1;
                            }
                            if (processor_arr[i].work.ElementAt(j) != -1)
                            {
                                processor_arr[i].power += 1;
                            }
                        }
                    }
                }
            }
        }

        public void Round_Robin()
        {
            PriorityQueue2 at_pq = new PriorityQueue2();
            for (int i = 0; i < process_n; i++)
            {  //AT우선순위 큐에 프로세스들 넣기
                at_pq.Push(process_arr[i]);
            }
            List<Process> readyList_AT = new List<Process>();
            for (int i = 0; i < process_n; i++)
            {  //AT우선순위 큐를 리스트로 복사
                readyList_AT.Add(at_pq.Pop());
            }
            Queue<Process> ready_q = new Queue<Process>();
            ready_q.Enqueue(readyList_AT[0]);
            readyList_AT.RemoveAt(0);

            while (readyList_AT.Count() != 0 || ready_q.Count() != 0)
            {
                Process nP = ready_q.Dequeue();
                int pat = nP.AT;
                int pi = find_empty_core(pat);
                while (pi == -1)
                {
                    pat++;
                    pi = find_empty_core(pat);
                }
                if (nP.fi_c)
                {
                    st_t[nP.PID] = pat;
                    nP.fi_c = false;
                }
                while (processor_arr[pi].work.Count < pat)
                {
                    processor_arr[pi].work.Add(-1);
                }
                int ch_tq = 0;
                while (ch_tq < processor_arr[pi].time_q && nP.re_t > 0)
                {
                    if (processor_arr[pi].core == 'p')
                    {
                        processor_arr[pi].work.Add(nP.PID);
                        nP.re_t -= 2;
                        nP.RBT++;
                        ch_tq++;
                    }
                    else
                    {
                        processor_arr[pi].work.Add(nP.PID);
                        nP.re_t--;
                        nP.RBT++;
                        ch_tq++;
                    }
                }
                for (int i = 0; i < readyList_AT.Count; i++) //리스트를 탐색하며 정지시간 전에 들어온 프로세스들을 레디 큐에 넣는다.
                {
                    if (readyList_AT[i].AT <= pat + ch_tq)
                    {
                        ready_q.Enqueue(readyList_AT[i]);
                        readyList_AT.RemoveAt(i);
                    }
                }
                if (nP.re_t < 1)
                {
                    nP.terminateTime = processor_arr[pi].work.Count;
                }
                else
                {
                    nP.AT = pat + ch_tq;
                    ready_q.Enqueue(nP);
                }
            }
            core_power();
            CalTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].TT = tt[i];
            }
            CalWT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].WT = wt[i];
            }
            CalNTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].NTT = ntt[i];
            }
            for (int i = 0; i < process_n; i++)
            {
                bt[i] = process_arr[i].RBT;
            }
            for (int i = 0; i < processor_n; i++)
            {
                power[i] = processor_arr[i].power;
            }
        }

        public void shortest_Process_Next()
        {
            PriorityQueue2 ready_pq = new PriorityQueue2();  //AT 우선순위 큐
            for (int i = 0; i < process_n; i++)
            {
                ready_pq.Push(process_arr[i]);
            }
            List<Process> readyList_AT = new List<Process>();
            for (int i = 0; i < process_n; i++)
            {  //AT우선순위 큐를 리스트로 복사
                readyList_AT.Add(ready_pq.Pop());
            }

            PriorityQueue ready_pq2 = new PriorityQueue(); //BT우선순위 큐
            ready_pq2.Push(readyList_AT[0]); //BT우선순위 큐에 AT배열 첫 요소 넣기
            readyList_AT.RemoveAt(0);
            while (ready_pq2.Count() != 0)
            {
                Process nP = ready_pq2.Pop();
                int pat = nP.AT;  //프로세스n의 도착시간
                int pi = find_empty_core(pat); //도착시간에 비어있는 코어 찾기
                while (pi == -1)
                {
                    pat++;
                    pi = find_empty_core(pat);
                }
                st_t[nP.PID] = pat;  //실제 시작 시간
                while (processor_arr[pi].work.Count < pat) //프로세스 시작 전까지 -1 넣기
                {
                    processor_arr[pi].work.Add(-1);
                }
                if (processor_arr[pi].core == 'p')
                {
                    while (nP.re_t > 0)
                    {
                        processor_arr[pi].work.Add(nP.PID);
                        nP.re_t -= 2;
                        nP.RBT++;
                    }
                    nP.terminateTime = processor_arr[pi].work.Count;
                }
                else
                {
                    while (nP.re_t > 0)
                    {
                        processor_arr[pi].work.Add(nP.PID);
                        nP.re_t--;
                        nP.RBT++;
                    }
                    nP.terminateTime = processor_arr[pi].work.Count;
                }
                for (int i = 0; i < readyList_AT.Count; i++) //리스트를 탐색하며 종료시간 전에 들어온 프로세스들을 BT우선순위 큐에 넣는다.
                {
                    if (readyList_AT[i].AT <= nP.terminateTime)
                    {
                        ready_pq2.Push(readyList_AT[i]);
                        readyList_AT.RemoveAt(i);
                    }
                }


            }
            core_power();
            CalTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].TT = tt[i];
            }
            CalWT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].WT = wt[i];
            }
            CalNTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].NTT = ntt[i];
            }
            for (int i = 0; i < process_n; i++)
            {
                bt[i] = process_arr[i].RBT;
            }
            for (int i = 0; i < processor_n; i++)
            {
                power[i] = processor_arr[i].power;
            }

        }

        public void SRTN()
        {
            PriorityQueue2 at_pq = new PriorityQueue2();
            for (int i = 0; i < process_n; i++)
            {  //AT우선순위 큐에 프로세스들 넣기
                at_pq.Push(process_arr[i]);
            }
            List<Process> readyList_AT = new List<Process>();
            for (int i = 0; i < process_n; i++)
            {  //AT우선순위 큐를 리스트로 복사
                readyList_AT.Add(at_pq.Pop());
            }
            PriorityQueue ready_q = new PriorityQueue();
            int stAT = readyList_AT[0].AT;
            Process[] p_st = new Process[processor_n];
            int pr_chn = 0;
            while (readyList_AT[0].AT == stAT)
            {
                ready_q.Push(readyList_AT[0]);
                readyList_AT.RemoveAt(0);
            }
            while (pr_chn < processor_n)
            {
                if (pr_chn < ready_q.Count())
                {
                    p_st[pr_chn] = ready_q.Pop();
                }
                else
                {
                    p_st[pr_chn] = null;
                }
                pr_chn++;
            }
            int run_t = 0;
            int null_c = 0;
            while (readyList_AT.Count() != 0 || ready_q.Count() != 0 || null_c < processor_n)
            {
                null_c = 0;
                for (int i = 0; i < processor_n; i++)
                {
                    if (p_st[i] == null)
                    {
                        processor_arr[i].work.Add(-1);
                        null_c++;
                    }
                    else
                    {
                        if (processor_arr[i].core == 'p')
                        {
                            processor_arr[i].work.Add(p_st[i].PID);
                            p_st[i].re_t -= 2;
                            p_st[i].RBT++;
                        }
                        else
                        {
                            processor_arr[i].work.Add(p_st[i].PID);
                            p_st[i].re_t--;
                            p_st[i].RBT++;
                        }
                        if (p_st[i].fi_c)
                        {
                            st_t[p_st[i].PID] = run_t;
                            p_st[i].fi_c = false;
                        }
                    }
                    if (p_st[i]!=null && p_st[i].re_t <= 0)
                    {
                        p_st[i].terminateTime = run_t + 1;
                        p_st[i] = null;
                        null_c++;
                    }
                }
                run_t++;
                int idx = 0;
                while (readyList_AT.Count != 0 && readyList_AT[idx].AT <= run_t)
                {
                    ready_q.Push(readyList_AT[0]);
                    readyList_AT.RemoveAt(0);
                }
                if (ready_q.Count() != 0)
                {
                    if (null_c > 0)
                    {
                        for (int j = 0; j < processor_n; j++)
                        {
                            if (p_st[j] == null && null_c > 0 && ready_q.Count() != 0)
                            {
                                p_st[j] = ready_q.Pop();
                                null_c--;
                            }
                        }
                    }
                    if (ready_q.Count() != 0)
                    {
                        for (int j = 0; j < processor_n; j++)
                        {
                            if (p_st[j].re_t > ready_q._heap[0].re_t)
                            {
                                ready_q.Push(p_st[j]);
                                p_st[j] = ready_q.Pop();
                                j = -1;
                            }
                        }
                    }
                }
            }
            core_power();
            CalTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].TT = tt[i];
            }
            CalWT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].WT = wt[i];
            }
            CalNTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].NTT = ntt[i];
            }
            for (int i = 0; i < process_n; i++)
            {
                bt[i] = process_arr[i].RBT;
            }
            for (int i = 0; i < processor_n; i++)
            {
                power[i] = processor_arr[i].power;
            }
        }

        public void FCFS()
        {
            PriorityQueue2 ready_pq = new PriorityQueue2();
            for (int i = 0; i < process_n; i++)
            {
                ready_pq.Push(process_arr[i]);
            }
            for (int i = 0; i < process_n; i++)
            {
                Process nP = ready_pq.Pop();
                int pat = nP.AT;
                int pi = find_empty_core(pat);
                while (pi == -1)
                {
                    pat++;
                    pi = find_empty_core(pat);
                }
                st_t[nP.PID] = pat;
                while (processor_arr[pi].work.Count < pat)
                {
                    processor_arr[pi].work.Add(-1);
                }
                if (processor_arr[pi].core == 'p')
                {
                    while (nP.re_t > 0)
                    {
                        processor_arr[pi].work.Add(nP.PID);
                        nP.re_t -= 2;
                        nP.RBT++;
                    }
                    nP.terminateTime = processor_arr[pi].work.Count;
                }
                else
                {
                    while (nP.re_t > 0)
                    {
                        processor_arr[pi].work.Add(nP.PID);
                        nP.re_t--;
                        nP.RBT++;
                    }
                    nP.terminateTime = processor_arr[pi].work.Count;
                }

            }
            core_power();
            CalTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].TT = tt[i];
            }
            CalWT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].WT = wt[i];
            }
            CalNTT();
            for (int i = 0; i < process_n; i++)
            {
                process_arr[i].NTT = ntt[i];
            }
            for (int i = 0; i < process_n; i++)
            {
                bt[i] = process_arr[i].RBT;
            }
            for (int i = 0; i < processor_n; i++)
            {
                power[i] = processor_arr[i].power;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] atr = { 0, 2, 4, 2 };
            int[] btr = { 10, 8, 6, 6 };
            Schedul s = new Schedul(4, 2, 1, atr, btr, 3);
            s.SRTN();
            foreach (int n in s.wt)
            {
                Console.Write(n + ", ");
            }
            foreach (int n in s.bt)
            {
                Console.Write(n + ", ");
            }
            foreach (int n in s.tt)
            {
                Console.Write(n + ", ");
            }
            foreach (int n in s.ntt)
            {
                Console.Write(n + ", ");
            }
            foreach (double n in s.power)
            {
                Console.Write(n + ", ");
            }
        }
    }
}
