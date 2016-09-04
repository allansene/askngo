import xmltodict,json
#####################
def manageData(prefix,adress):
    totalPost = 0
    #user
    xml = " ".join(open(prefix+adress+"/Users.xml",encoding="utf8").readlines())
    d = xmltodict.parse(xml)
    actionLine = "{\"index\":{ \"_index\":\"teste4\",\"_type\":\"user\",\"_id\":"
    keysToDelete = ['@Reputation','@CreationDate','@LastAccessDate','@LastEditDate','@AnswerCount','@CommentCount','@Location','@UpVotes','@EmailHash','@AccountId','@Age','@Views','@@WebsiteUrl']
    convertToInt = ['@Id','@PostTypeId','@ViewCount','@OwnerUserId','@AnswerCount','@CommentCount']
    file = open(prefix+adress+"Users.json",'w')
    for i in d['users']['row']:
        for j in keysToDelete:
            if j in i:
                del i[j]
        for j in convertToInt:
            if j in i:
                i[j] = int(i[j])
        file.write(actionLine+str(i['@Id'])+"}}\n")
        file.write(str("{\"user\":"+json.dumps(i)+'}\n').replace("@",""))
    file.close()
    #
    #posts
    xml = " ".join(open(prefix+adress+"/Posts.xml",encoding="utf8").readlines())
    d = xmltodict.parse(xml)
    actionLine = "{\"index\":{ \"_index\":\"teste4\",\"_type\":\"post\",\"_id\":"
    keysToDelete = ['@DeletionDate','@ViewCount','@LastEditorUserId','@LastEditorDisplayName','@LastActivtyDate','@Tags','@FavoriteCount','@CommunityOwnedDate']
    convertToInt = ['@Id','@PostTypeId','@Views','@AcceptedAnswerId','@ParentId','@Score']
    for i in d['posts']['row']:
        for j in keysToDelete:
            if j in i:
                del i[j]
        for j in convertToInt:
            if j in i:
                i[j] = int(i[j])
    idsNotDelete = [1,2]
    postsToDelete = []
    for i in d['posts']['row']:
        if i['@PostTypeId'] not in idsNotDelete:
            postsToDelete.append(i)
    for i in postsToDelete:
        d['posts']['row'].remove(i)
    file = open(prefix+adress+"Posts.json",'w')
    for i in d['posts']['row']:        
        file.write(actionLine+str(i['@Id'])+"},\"Relevance\":\"[]\"}\n")
        file.write(str("{\"post\":"+json.dumps(i)+'}\n').replace("@",""))
    file.close()
###################
prefix = "hackathon/"
adresses = ['cs','cstheory','datascience']
for i in adresses:
    manageData(prefix,i)