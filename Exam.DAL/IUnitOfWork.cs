namespace Exam.DAL
{
    /// <summary>
    /// Единица работы с БД
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Применить изменения
        /// </summary>
        /// <returns>Кол-во измененных строк</returns>
        int Commit();
    }
}
