namespace MemoryLeak
{
    public class InfiniteLoop
    {
        private List<int> numbers = new List<int>();

        public bool AddNumbers()
        {
            while (true)
            {
                numbers.Add(1); // Sonsuz olaraq 1 əlavə edir
                                // Növbəti dövrə keçməzdən əvvəl heç bir şey azad etmirik
            }
        }
    }
}

//Nə baş verir?
//numbers siyahısına hər dəfə yeni 1 əlavə olunur, amma heç bir zaman həmin siyahı təmizlənmir.
//Nəticə etibarilə list daha çox yaddaş tutur və heç bir zaman boşalmır.
//Proqram işlədikcə bu sızıntı davam edir və zamanla tətbiqin yaddaşı yavaş-yavaş dolur.