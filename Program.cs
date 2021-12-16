using System;

namespace RPGgame
{
    class Program
    {

        static void Main(string[] args)
        {
            SkillList list = new SkillList();
            while (true)
            {
                Console.Write("Input skill name : ");
                string skillname = Console.ReadLine();
                Skill skill = new Skill(skillname);
                list.AddSkill(skill);
                while (true)
                {
                    Console.WriteLine("Add dependency for {0}? (Y/N): ", skill.name);
                    string choose = Console.ReadLine();
                    int order = 0;
                    if (choose == "Y")
                    {
                        while (true)
                        {
                            Console.Write("Input skill name : ");
                            string skillSecname = Console.ReadLine();
                            order++;
                            skill.Add(skill.Order(order, skillSecname));
                            skill.nextSkill = skill.Order(order, skillSecname);
                            while (true)
                            {
                                Console.WriteLine("Add dependency for {0}? (Y/N): ", skill.nextSkill.name);
                                choose = Console.ReadLine();
                                if (choose == "Y")
                                {
                                    skill = skill.nextSkill;
                                    skill.preSkill = skill;
                                    break;
                                }
                                else if (choose == "N")
                                {
                                    skill.nextSkill = skill;
                                    skill = skill.preSkill;
                                    if(skill.preSkill == null)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (skill.preSkill == null)
                            {
                                break;
                            }
                        }
                    }
                    else if (choose == "N")
                    {

                    }
                    else if (choose == "?")
                    {
                        break;
                    }
                }
            }

        }
    }
    class Skill
    {
        public string name;
        public int order;
        public Skill nextSkill;
        public Skill preSkill;
        public Skill nextList;
        public Skill List;
        public Skill(string nameValue)
        {
            name = nameValue;
            nextSkill = null;
            nextList = null;
            preSkill = null;
        }
        public Skill Order(int orderValue,string nameValue)
        {
            Skill skillOrder = new Skill(nameValue);
            skillOrder.order = orderValue;
            return skillOrder;
    }
        public void Add(Skill skills)
        {
            if(List == null)
            {
                List = skills;
            }
            else 
            {
                Skill level = List;
                while(level.nextList != null)
                {
                    level = level.nextList;

                }
                
                level.nextList = skills;

            }
        }
    }
    class SkillList
    {
        public Skill skill;
       
        public SkillList()
        {
            
        }
        public void AddSkill(Skill skills)
        {
            if(skill == null)
            {
                skill = skills;
            }
            else
            {
                Skill level = skill;
                while (level.nextList != null)
                {
                    level = level.nextList;
                }
                level.nextList = skills;
            }
        }
    }
}
