# textToolsTask

## Решение тестового задания на вакансию Программист-разработчик C#

## Постановка:

## Тестовое задание
Разработать на C# два консольных приложения, выполняющие следующие функции:
Загрузка данных из текстового файла в базу данных.
Выгрузка информации из базы данных по заданному критерию.

### 1. Требования к приложению загрузки данных (из файла в БД)
Приложение должно загружать в базу данных из входного текстового файла (который может содержать текст на английском и русском языках, в кодировке UTF-8) все слова, удовлетворяющие следующим критериям:
длина слова не менее 3 и не более 20 символов;
слово упоминается в текущем входном файле не менее 4-ёх раз.
Загрузка может выполняться многократно. При этом приложение не должно удалять существующие данные из базы данных, а должно дополнять их.
В базе данных для каждого сохранённого слова должно храниться количество его упоминаний, суммарное для всех загруженных файлов (т.е. в результате загрузки каждого нового файла существующее в базе данных количество упоминаний должно быть увеличено на количество упоминаний в новом файле).
Текстовый файл, подаваемый на вход, должен быть в кодировке UTF-8. Файл может содержать любые буквы (латиница и кириллица) и пробелы. Файл может содержать более одной строки. Файл может иметь размер до 100 МБ.
Приложение должно корректно обновлять информацию в базе данных в случае, если одновременно выполняется несколько копий этого приложения, работающих с одной и той же базой данных.
Приложение должно автоматически создавать и инициализировать базу данных (включая её таблицы и т.д.) в случае, если таковая отсутствует; либо должен быть предоставлен SQL-скрипт для её первичного создания.
База данных должна быть реализована с использованием MS SQL Server / SQL Server Express.

### 2. Требования к приложению выгрузки (из БД в консоль)
Приложение должно принимать в виде входного параметра строку (содержащую слово или его часть) и выводить в консоль те слова из базы данных, которые начинаются с указанной строки и при этом имеют наибольшее количество упоминаний в базе данных.
Выводимые слова должны быть отсортированы в порядке убывания количества их упоминаний в базе данных. В случае совпадения количества упоминаний у разных слов таковые должны отсортированы по алфавиту.
Должно быть выведено не более 5 слов, удовлетворяющих вышеописанным критериям.
При выводе в консоль слова должны быть разделены переводом строки.
