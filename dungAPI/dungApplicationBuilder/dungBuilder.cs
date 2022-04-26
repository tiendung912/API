namespace dungAPI.dungapplicationBuilderlicationBuilder
{
    public static class dungBuilder
    {
        public static void useDungBuilder(this IApplicationBuilder applicationBuilder, bool IsDevelopment)
        {
            // Configure the HTTP request pipeline.
            if (IsDevelopment)
            {
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI();
            }

            applicationBuilder.UseHttpsRedirection();

        }
    }
}