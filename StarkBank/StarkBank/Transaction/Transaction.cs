﻿using System;
using System.Linq;
using System.Collections.Generic;


namespace StarkBank
{
    /// <summary>
    /// Transaction object
    /// <br/>
    /// A Transaction is a transfer of funds between workspaces inside Stark Bank.
    /// Transactions created by the user are only for internal transactions.
    /// Other operations (such as transfer or charge-payment) will automatically
    /// create a transaction for the user which can be retrieved for the statement.
    /// When you initialize a Transaction, the entity will not be automatically
    /// created in the Stark Bank API. The 'create' function sends the objects
    /// to the Stark Bank API and returns the list of created objects.
    /// <br/>
    /// Properties:
    /// <list>
    ///     <item>Amount [long integer]: amount in cents to be transferred. ex: 1234 (= R$ 12.34)</item>
    ///     <item>Description [string]: text to be displayed in the receiver and the sender statements (Min. 10 characters). ex: "funds redistribution"</item>
    ///     <item>ExternalID [string]: unique id, generated by user, to avoid duplicated transactions. ex: "transaction ABC 2020-03-30"</item>
    ///     <item>ReceivedID [string]: unique id of the receiving workspace. ex: "5656565656565656"</item>
    ///     <item>SenderID [string]: unique id of the sending workspace. ex: "5656565656565656"</item>
    ///     <item>Tags [list of strings]: list of strings for reference when searching transactions (may be empty). ex: ["abc", "test"]</item>
    ///     <item>Source [string, default null]: locator of the entity that generated the transaction. ex: "charge/1827351876292", "transfer/92873912873/chargeback"</item>
    ///     <item>ID [string, default null]: unique id returned when Transaction is created. ex: "7656565656565656"</item>
    ///     <item>Fee [integer, default null]: fee charged when transfer is created. ex: 200 (= R$ 2.00)</item>
    ///     <item>Created [DateTime, default null]: creation datetime for the boleto. ex: DateTime.new(2020, 3, 10, 10, 30, 0, 0)</item>
    /// </list>
    /// </summary>
    public class Transaction : Utils.Resource
    {
        public long Amount { get; }
        public string ExternalID { get; }
        public string ReceiverID { get; }
        public string SenderID { get; }
        public List<string> Tags { get; }
        public int? Fee { get; }
        public string Description { get; }
        public string Source { get; }
        public DateTime? Created { get; }

        /// <summary>
        /// Transaction object
        /// <br/>
        /// A Transaction is a transfer of funds between workspaces inside Stark Bank.
        /// Transactions created by the user are only for internal transactions.
        /// Other operations (such as transfer or charge-payment) will automatically
        /// create a transaction for the user which can be retrieved for the statement.
        /// When you initialize a Transaction, the entity will not be automatically
        /// created in the Stark Bank API. The 'create' function sends the objects
        /// to the Stark Bank API and returns the list of created objects.
        /// <br/>
        /// Parameters (required):
        /// <list>
        ///     <item>amount [long integer]: amount in cents to be transferred. ex: 1234 (= R$ 12.34)</item>
        ///     <item>description [string]: text to be displayed in the receiver and the sender statements (Min. 10 characters). ex: "funds redistribution"</item>
        ///     <item>externalID [string]: unique id, generated by user, to avoid duplicated transactions. ex: "transaction ABC 2020-03-30"</item>
        ///     <item>receivedID [string]: unique id of the receiving workspace. ex: "5656565656565656"</item>
        /// </list>
        /// <br/>
        /// Parameters (optional):
        /// <list>
        ///     <item>tags [list of strings]: list of strings for reference when searching transactions (may be empty). ex: ["abc", "test"]</item>
        /// </list>
        /// <br/>
        /// Attributes (return-only):
        /// <list>
        ///     <item>senderID [string]: unique id of the sending workspace. ex: "5656565656565656"</item>
        ///     <item>source [string, default null]: locator of the entity that generated the transaction. ex: "charge/1827351876292", "transfer/92873912873/chargeback"</item>
        ///     <item>id [string, default null]: unique id returned when Transaction is created. ex: "7656565656565656"</item>
        ///     <item>fee [integer, default null]: fee charged when transfer is created. ex: 200 (= R$ 2.00)</item>
        ///     <item>created [DateTime, default null]: creation datetime for the boleto. ex: DateTime.new(2020, 3, 10, 10, 30, 0, 0)</item>
        /// </list>
        /// </summary>
        public Transaction(long amount, string externalID, string receiverID, string senderID = null, List<string> tags = null, string id = null,
            int? fee = null, string description = null, DateTime? created = null, string source = null) : base(id)
        {
            Amount = amount;
            ExternalID = externalID;
            ReceiverID = receiverID;
            SenderID = senderID;
            Tags = tags;
            Fee = fee;
            Description = description;
            Source = source;
            Created = created;
        }

        /// <summary>
        /// Create Transactions
        /// <br/>
        /// Send a list of Transaction objects for creation in the Stark Bank API
        /// <br/>
        /// Parameters (required):
        /// <list>
        ///     <item>transactions [list of Transaction objects]: list of Transaction objects to be created in the API</item>
        /// </list>
        /// <br/>
        /// Parameters (optional):
        /// <list>
        ///     <item>user [Project object]: Project object. Not necessary if StarkBank.User.Default was set before function call</item>
        /// </list>
        /// <br/>
        /// Return:
        /// <list>
        ///     <item>list of Transaction objects with updated attributes</item>
        /// </list>
        /// </summary>
        public static List<Transaction> Create(List<Transaction> transactions, User user = null)
        {
            (string resourceName, Utils.Api.ResourceMaker resourceMaker) = Resource();
            return Utils.Rest.Post(
                resourceName: resourceName,
                resourceMaker: resourceMaker,
                entities: transactions,
                user: user
            ).ToList().ConvertAll(o => (Transaction)o);
        }

        /// <summary>
        /// Create Transactions
        /// <br/>
        /// Send a list of Transaction objects for creation in the Stark Bank API
        /// <br/>
        /// Parameters (required):
        /// <list>
        ///     <item>transactions [list of Transaction objects]: list of Transaction objects to be created in the API</item>
        /// </list>
        /// <br/>
        /// Parameters (optional):
        /// <list>
        ///     <item>user [Project object]: Project object. Not necessary if StarkBank.User.Default was set before function call</item>
        /// </list>
        /// <br/>
        /// Return:
        /// <list>
        ///     <item>list of Transaction objects with updated attributes</item>
        /// </list>
        /// </summary>
        public static List<Transaction> Create(List<Dictionary<string, object>> transactions, User user = null)
        {
            (string resourceName, Utils.Api.ResourceMaker resourceMaker) = Resource();
            return Utils.Rest.Post(
                resourceName: resourceName,
                resourceMaker: resourceMaker,
                entities: transactions,
                user: user
            ).ToList().ConvertAll(o => (Transaction)o);
        }

        /// <summary>
        /// Retrieve a specific Transaction
        /// <br/>
        /// Receive a single Transaction object previously created in the Stark Bank API by passing its id
        /// <br/>
        /// Parameters (required):
        /// <list>
        ///     <item>id [string]: object unique id. ex: "5656565656565656"</item>
        /// </list>
        /// <br/>
        /// Parameters (optional):
        /// <list>
        ///     <item>user [Project object]: Project object. Not necessary if StarkBank.User.Default was set before function call</item>
        /// </list>
        /// <br/>
        /// Return:
        /// <list>
        ///     <item>Transaction object with updated attributes</item>
        /// </list>
        /// </summary>
        public static Transaction Get(string id, User user = null)
        {
            (string resourceName, Utils.Api.ResourceMaker resourceMaker) = Resource();
            return Utils.Rest.GetId(
                resourceName: resourceName,
                resourceMaker: resourceMaker,
                id: id,
                user: user
            ) as Transaction;
        }

        /// <summary>
        /// Retrieve Transactions
        /// <br/>
        /// Receive an IEnumerable of Transaction objects previously created in the Stark Bank API
        /// <br/>
        /// Parameters (optional):
        /// <list>
        ///     <item>limit [integer, default null]: maximum number of objects to be retrieved. Unlimited if null. ex: 35</item>
        ///     <item>after [Date, default null] date filter for objects created only after specified date. ex: Date.new(2020, 3, 10)</item>
        ///     <item>before [Date, default null] date filter for objects created only before specified date. ex: Date.new(2020, 3, 10)</item>
        ///     <item>externalIds [list of strings, default null]: list of external ids to filter retrieved objects. ex: ["5656565656565656", "4545454545454545"]</item>
        ///     <item>user [Project object, default null]: Project object. Not necessary if StarkBank.User.Default was set before function call</item>
        /// </list>
        /// <br/>
        /// Return:
        ///     <item>IEnumerable of Transaction objects with updated attributes</item>
        /// </summary>
        public static IEnumerable<Transaction> Query(int? limit = null, DateTime? after = null, DateTime? before = null,
            List<string> externalIds = null, User user = null)
        {
            (string resourceName, Utils.Api.ResourceMaker resourceMaker) = Resource();
            return Utils.Rest.GetList(
                resourceName: resourceName,
                resourceMaker: resourceMaker,
                query: new Dictionary<string, object> {
                    { "limit", limit },
                    { "after", after },
                    { "before", before },
                    { "externalIds", externalIds }
                },
                user: user
            ).Cast<Transaction>();
        }

        internal static (string resourceName, Utils.Api.ResourceMaker resourceMaker) Resource()
        {
            return (resourceName: "Transaction", resourceMaker: ResourceMaker);
        }

        internal static Utils.Resource ResourceMaker(dynamic json)
        {
            string id = json.id;
            long amount = json.amount;
            string externalID = json.externalId;
            string receiverID = json.receiverId;
            string senderID = json.senderId;
            List<string> tags = json.tags.ToObject<List<string>>();
            int fee = json.fee;
            string description = json.description;
            string source = json.source;
            string createdString = json.created;
            DateTime? created = Utils.Checks.CheckDateTime(createdString);

            return new Transaction(
                id: id, amount: amount, externalID: externalID, receiverID: receiverID, senderID: senderID, tags: tags, fee: fee,
                description: description, source: source, created: created
            );
        }
    }
}
