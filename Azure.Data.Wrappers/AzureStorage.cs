﻿namespace Azure.Data.Wrappers
{
    using Microsoft.WindowsAzure.Storage;
    using System;

    /// <summary>
    /// Azure Storage
    /// </summary>
    public class AzureStorage : IStorageAccount
    {
        #region Members
        /// <summary>
        /// Cloud Storage Account
        /// </summary>
        private readonly CloudStorageAccount account;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        public AzureStorage(string connectionString)
            : this(CloudStorageAccount.Parse(connectionString))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="account">Storage Account</param>
        public AzureStorage(CloudStorageAccount account)
        {
            if (null == account)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.account = account;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Cloud Storage Account
        /// </summary>
        public CloudStorageAccount Account
        {
            get
            {
                return this.account;
            }
        }

        public string GetSharedAccessSignature(SharedAccessAccountPolicy policy)
        {
            if (policy == null) throw new ArgumentNullException(nameof(policy));

            return this.account.GetSharedAccessSignature(policy);
        }
        #endregion
    }
}