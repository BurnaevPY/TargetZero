namespace TargetZero.Domain
{
    /// <summary>
    /// Рассмотрение рацпредложений
    /// </summary>
    public class Consideration
    {
        /// <summary>
        /// Идентификатор рассмотрения
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Результат рассмотрения
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Рекомендательный статус
        /// </summary>
        //public InnovationStatus InnovationStatus { get; private set; }

        /// <summary>
        /// Группа рассмотрения
        /// </summary>
        public ConsiderationGroup ConsiderationGroup { get; private set; }

        public ConsiderationResult ConsiderationResult { get; private set; }

        /// <summary>
        /// Рассматриваемое предложение
        /// </summary>
        public int InnovationId { get; private set; }

        public static Consideration Create(
            ConsiderationGroup considerationGroup, 
            ConsiderationResult considerationResult,
            //InnovationStatus innovationStatus, 
            int innovationId, string content)
        {
            return new Consideration
            {
                ConsiderationResult = considerationResult,
                ConsiderationGroup = considerationGroup,
                //InnovationStatus = innovationStatus,
                InnovationId = innovationId,
                Content = content
            };
        }

        public void SetRecommendation(
            ConsiderationResult considerationResult,
            //InnovationStatus innovationStatus, 
            string content)
        {
            Content = content;
            //InnovationStatus = innovationStatus;
            ConsiderationResult = considerationResult;
        }

    }
}
